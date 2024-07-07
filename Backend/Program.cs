using AutoMapper;
using Merchanmusic.Data;
using Merchanmusic.Data.Entities;
using Merchanmusic.Data.Mapping_Profiles;
using Merchanmusic.Data.Models;
using Merchanmusic.Services.Implementations;
using Merchanmusic.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Security.Cryptography.X509Certificates;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration["Database:ConnectionString"];
var connectionString = builder.Configuration["Database:LocalConnectionString"];
var serverVersion = new MySqlServerVersion(new Version(6, 0, 1));

builder.Services.AddAutoMapper(typeof(MappingProfile));

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);
builder.Services.AddDbContext<MerchContext>(
    dbContextOptions => dbContextOptions
        .UseMySql(connectionString, serverVersion)
        .LogTo(Console.WriteLine, LogLevel.Information)
        .EnableSensitiveDataLogging()
        .EnableDetailedErrors()
);

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(setupAction =>
{
    setupAction.AddSecurityDefinition("MerchanmusicBearerAuth", new OpenApiSecurityScheme() //Esto va a permitir usar swagger con el token.
    {
        Type = SecuritySchemeType.Http,
        Scheme = "Bearer",
        Description = "Acá pegar el token generado al loguearse."
    });

    setupAction.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type = ReferenceType.SecurityScheme,
                    Id = "MerchanmusicBearerAuth" }
                }, new List<string>() }
    });
}); ;

builder.Configuration.AddUserSecrets<Program>();

builder.Services.AddHttpContextAccessor();

#region Services

builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<ISaleOrderService, SaleOrderService>();
builder.Services.AddScoped<ISaleOrderLineService, SaleOrderLineService>();
builder.Services.AddScoped<IProductService, ProductService>();
builder.Services.AddScoped<ITokenService, TokenService>();

#endregion

var certificate = @"-----BEGIN CERTIFICATE-----
MIIDHTCCAgWgAwIBAgIJYvWcgGRO6CKMMA0GCSqGSIb3DQEBCwUAMCwxKjAoBgNV
BAMTIWRldi1hNjRnbHE1eWdsZGh1eTFnLnVzLmF1dGgwLmNvbTAeFw0yNDA1MjQw
MDA5MzBaFw0zODAxMzEwMDA5MzBaMCwxKjAoBgNVBAMTIWRldi1hNjRnbHE1eWds
ZGh1eTFnLnVzLmF1dGgwLmNvbTCCASIwDQYJKoZIhvcNAQEBBQADggEPADCCAQoC
ggEBALMnLBwsgYwa10Aa1ltO+26kVMtNO3rN9iCchAsMSQLxXN8Wva9n37Pz5Czr
V0EOiGWFBqSzMTk6VrJFL/VICiSHO4FXQmV8Vs/1Uj2VEb8jDjfSXIriDFbdWzry
957bec/Bt4N0Avbx3lHHId9RUkWkoepkNIi5CxLHySK3WYVyLJWbbxUDI+yIDWUZ
zgMujJlUvn8xUPokWDskN/PPgVS+AQzRzb19AYaLNY1FZikG63hwc82H7jLJF3Mj
3/BwfaZinML9/aPzWhK498Si//e7XXeyMk7MwZFC3kSG2QcmiOewwwGG2oqhaAqH
zLsz4u2Tp3ybp4LKCZg55mbKK3cCAwEAAaNCMEAwDwYDVR0TAQH/BAUwAwEB/zAd
BgNVHQ4EFgQUEJmeLlGwMbapq+VOIOdgQ8vTIeIwDgYDVR0PAQH/BAQDAgKEMA0G
CSqGSIb3DQEBCwUAA4IBAQCkmp5NgwxfSn6mafHC//h3ZmKc6RPv8kz9PZ+ftB1H
VSpJ2Z5hlqHyzVm9VZEtYHRaBTn+EFVZzUVi07xFhZIIdedRQBX5Ymu2eFwhpP7S
bW21OHi+C8HtXioHP6ax+DF/2JJu5OXwQQu+yQW9d/boTNEf6H3j3GcUh6FfuDjg
5g0amp5a/AykEQS+pZwSzf3YAr+IgMdJoTTMyAYLQZ/3x+4a6PyF09Gcbqv9XBt+
kGs4w7prfi2bh0Zx+0M6C5OnEp1FbwQyq1QM1f6ZLNx6AY3TAWmw4XTRQTlz24Tq
mAafa1FD6LjuHAAjWmQEc/GrYfi7D87IW0WXZEsxbmsT
-----END CERTIFICATE-----";
var certificateBytes = Convert.FromBase64String(
    certificate.Replace("-----BEGIN CERTIFICATE-----", "")
               .Replace("-----END CERTIFICATE-----", "")
               .Replace("\n", "")
               .Replace("\r", "")
);

var x509Certificate = new X509Certificate2(certificateBytes);
var securityKey = new X509SecurityKey(x509Certificate);

var domain = $"https://{builder.Configuration["Auth0:Domain"]}/";
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => //Acá definimos la configuración de la autenticación. le decimos qué cosas queremos comprobar. La fecha de expiración se valida por defecto.
    {
        options.Authority = domain;
        options.Audience = builder.Configuration["Auth0:Audience"];
        options.TokenValidationParameters = new()
        {
            NameClaimType = ClaimTypes.NameIdentifier,
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidIssuer = domain,
            ValidAudience = builder.Configuration["Auth0:Audience"],
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = securityKey,
        };
        options.Configuration = new Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration();
    }
);
builder.Services.AddCors(options => //habilitamos las solicitudes Cross-Origin
{
    options.AddPolicy("AllowAll", builder =>
    {
        builder.AllowAnyOrigin()
               .AllowAnyMethod()
               .AllowAnyHeader();
    });
});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors("AllowAll");
app.UseHttpsRedirection();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
