using BLL.Interfaces;
using BLL.Services;
using DAL.Interfaces;
using DAL.Services;
using API.Tools;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using System.Data.SqlClient;
using System.Text;
using Tools;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();

//injection token
builder.Services.AddScoped<ITokenManager, TokenManager>();

//injection user
builder.Services.AddScoped<IUserDal, UserDalService>();
builder.Services.AddScoped<IUserBll, UserBllService>();


string connectionString = builder.Configuration.GetConnectionString("Labo");
// service de connection a la base de donnée
builder.Services.AddTransient<Connection>(sp => new Connection(SqlClientFactory.Instance, connectionString));// addTransient == une instance par demande


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Name = "Authorization",
        Description = "Bearer Authentication with JWT Token",
        Type = SecuritySchemeType.Http
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Id = "Bearer",
                    Type = ReferenceType.SecurityScheme
                }
            },
            new List<string>()
        }
    });
});

// service gestion Token
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {
        options.TokenValidationParameters = new TokenValidationParameters()
        {
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(TokenManager.secret)),
            ValidateIssuer = true,
            ValidIssuer = TokenManager.myIssuer,
            ValidateAudience = true,
            ValidAudience = TokenManager.myAudience
        };
    });

//builder.Services.AddAuthorization(options =>
//{
//options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
//options.AddPolicy("Auth", policy => policy.RequireAuthenticatedUser());
//});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
