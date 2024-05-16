    using Merchanmusic.Data;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Text;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers().AddNewtonsoftJson(options => options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);


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

builder.Services.AddDbContext<MerchContext>(dbContextOptions =>

{
    var connectionString = builder.Configuration.GetConnectionString("MyConnectionString");
    var dbPassword = builder.Configuration["DbPassword"];

    connectionString = connectionString.Replace("{DbPassword}", dbPassword); //uso de un user-secret para no publicar la contraseña de acceso SQL Server al repositorio público de GitHub

    dbContextOptions.UseSqlServer(connectionString); //cambiamos el motor de la base de datos de SQLite a SQL Server para poder deployar el back-end en Azure (no admite SQLite nativamente)
});






//#regionServices

builder.Services.AddScoped<IUserService, UserService>(); 
builder.Services.AddScoped<ISaleOrderService, SaleOrderService>();

//#endregion

//builder.Services.AddHttpContextAccessor();

builder.Services.AddAuthentication("Bearer") //"Bearer" es el tipo de auntenticación 
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new()
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateIssuerSigningKey = true,
            ValidIssuer = builder.Configuration["Authentication:Issuer"],
            ValidAudience = builder.Configuration["Authentication:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.ASCII.GetBytes(builder.Configuration["Authentication:SecretForKey"]))
        };
    }
);
//builder.Services.AddCors(options => //habilitamos las solicitudes Cross-Origin para deployar correctamente el back-end en Azure
//{
//    options.AddPolicy("AllowAll", builder =>
//    {
//        builder.AllowAnyOrigin()
//               .AllowAnyMethod()
//               .AllowAnyHeader();
//    });
//});                                       SI CONECTAMOS CON AZURE


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();
