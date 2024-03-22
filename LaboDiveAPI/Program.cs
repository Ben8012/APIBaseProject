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
using Microsoft.AspNetCore.Http.Connections;
using API.Hubs;

var builder = WebApplication.CreateBuilder(args);
// Add services to the container.
builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSignalR();

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

// service gestion des autorisations
builder.Services.AddAuthorization(options =>
{
    //options.AddPolicy("Admin", policy => policy.RequireRole("Admin"));
    options.AddPolicy("Auth", policy => policy.RequireAuthenticatedUser());
});


// service gestion cors
builder.Services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
{
    builder.WithOrigins("http://localhost:4200")
    .AllowAnyMethod()
    .AllowAnyHeader()
    .AllowCredentials();
}));



//injection token
builder.Services.AddScoped<ITokenManager, TokenManager>();

//injection user
builder.Services.AddScoped<IUserDal, UserDalService>();
builder.Services.AddScoped<IUserBll, UserBllService>();
//injection club
builder.Services.AddScoped<IClubDal, ClubDalService>();
builder.Services.AddScoped<IClubBll, ClubBllService>();
//injection divelog
builder.Services.AddScoped<IDivelogDal, DivelogDalService>();
builder.Services.AddScoped<IDivelogBll, DivelogBllService>();
//injection diveplace
builder.Services.AddScoped<IDiveplaceDal, DiveplaceDalService>();
builder.Services.AddScoped<IDiveplaceBll, DiveplaceBllService>();
//injection event
builder.Services.AddScoped<IEventDal, EventDalService>();
builder.Services.AddScoped<IEventBll, EventBllService>();
//injection insurance
builder.Services.AddScoped<IInsuranceDal, InsuranceDalService>();
builder.Services.AddScoped<IInsuranceBll, InsuranceBllService>();
//injection message
builder.Services.AddScoped<IMessageDal, MessageDalService>();
builder.Services.AddScoped<IMessageBll, MessageBllService>();
//injection organisation
builder.Services.AddScoped<IOrganisationDal, OrganisationDalService>();
builder.Services.AddScoped<IOrganisationBll, OrganisationBllService>();
//injection organisation
builder.Services.AddScoped<ITrainingDal, TrainingDalService>();
builder.Services.AddScoped<ITrainingBll, TrainingBllService>();


string connectionString = builder.Configuration.GetConnectionString("Labo");
// service de connection a la base de donnée
builder.Services.AddTransient<Connection>(sp => new Connection(SqlClientFactory.Instance, connectionString));// addTransient == une instance par demande


// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("MyPolicy");
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.MapHub<ChatHub>("/chat", options =>
{
    options.Transports = HttpTransportType.WebSockets | HttpTransportType.LongPolling;
});



app.Run();
