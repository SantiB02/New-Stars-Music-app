using Merchanmusic.Data;
using Merchanmusic.Services.Implementations;
using Merchanmusic.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Security.Claims;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

//var connectionString = builder.Configuration["Database:ConnectionString"];
var connectionString = builder.Configuration["Database:LocalConnectionString"];
var serverVersion = new MySqlServerVersion(new Version(6, 0, 1));


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

//builder.Services.AddDbContext<MerchContext>(dbContextOptions =>

//{
//    var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
//    var dbPassword = builder.Configuration["DbPassword"];

//    connectionString = connectionString.Replace("{DbPassword}", dbPassword); //uso de un user-secret para no publicar la contraseña de acceso SQL Server al repositorio público de GitHub

//    //dbContextOptions.UseSqlServer(connectionString); //cambiamos el motor de la base de datos de SQLite a SQL Server para poder deployar el back-end en Azure (no admite SQLite nativamente)
//});






//#regionServices

builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<ISaleOrderService, SaleOrderService>();
builder.Services.AddScoped<IProductService, ProductService>();

//#endregion

//builder.Services.AddHttpContextAccessor();

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
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Auth0:SecretForKey"]))
        };
        options.Configuration = new Microsoft.IdentityModel.Protocols.OpenIdConnect.OpenIdConnectConfiguration();
    }
);
builder.Services.AddCors(options => //habilitamos las solicitudes Cross-Origin para deployar correctamente el back-end en Azure
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
