using BusinessLogics;
using Contracts.BusinessLogicContracts;
using Contracts.StoragesContracts;
using DatabaseImplement.Implements;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using RestApi;
using System.Net;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddTransient<IPersonStorage, PersonStorage>();
builder.Services.AddTransient<IPersonLogic, PersonLogic>();
builder.Services.AddTransient<ITransportStorage, TransportStorage>();
builder.Services.AddTransient<ITransportLogic, TransportLogic>();
builder.Services.AddTransient<IRentStorage, RentStorage>();
builder.Services.AddTransient<IRentLogic, RentLogic>();
builder.Services.AddAuthorization();
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme).AddJwtBearer(options =>
 {
     options.RequireHttpsMetadata = false;
     options.TokenValidationParameters = new TokenValidationParameters
     {
         // укзывает, будет ли валидироваться издатель при валидации токена
         ValidateIssuer = true,
         // строка, представляющая издателя
         ValidIssuer = AuthOptions.ISSUER,

         // будет ли валидироваться потребитель токена
         ValidateAudience = true,
         // установка потребителя токена
         ValidAudience = AuthOptions.AUDIENCE,
         // будет ли валидироваться время существования
         ValidateLifetime = true,

         // установка ключа безопасности
         IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
         // валидация ключа безопасности
         ValidateIssuerSigningKey = true,
     };
 });
builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.Converters.Add(new JsonStringEnumConverter());

    options.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull;
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo
    { Title = "RestApi", Version = "v1" });
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json",
    "RestApi v1"));
}

app.UseHttpsRedirection();

app.UseMiddleware<AuthenticationMiddleware>();

app.UseAuthentication();

app.UseAuthorization();

app.MapControllers();

app.Run();
