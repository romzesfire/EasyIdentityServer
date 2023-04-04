using EasyIdentityServer.API.Validation;
using EasyIdentityServer.DAL.DatabaseContext;
using EasyIdentityServer.Domain.Model;
using EasyIdentityServer.DTO;
using EasyIdentityServer.DTO.Abstractions;
using EasyIdentityServer.Repository.Repositories;
using EasyIdentityServer.Service.Services;
using EasyTrade.API.Validation;
using EasyTradeLibs.Abstractions;
using EasyTradeLibs.Middleware;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var config = new ConfigurationBuilder()
    .AddJsonFile("appsettings.json")
    .Build();
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddSingleton<ISecretKeyGenerator, SecretKeyGenerator>();
builder.Services.AddDbContext<EasyIdentityDbContext>(o =>
{
    o.UseNpgsql(config.GetSection("Database:ConnectionString").Value);
});
builder.Services.AddHttpContextAccessor();
builder.Services.AddScoped<IRepository<Guid, User>, UserRepository>();
builder.Services.AddSingleton<IKeyHasher, KeyHasher>();
builder.Services.AddScoped<IUserRegister, UserRegister>();
builder.Services.AddScoped<IUserRecorder, UserRecorder>();
builder.Services.AddSingleton<ISecretKeyGenerator, SecretKeyGenerator>();
builder.Services.AddScoped<ITokenGenerator, TokenGenerator>();
builder.Services.AddSingleton<IValidationOptionsProvider, ValidationOptionsProvider>();
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMiddleware<RequestDurationMiddleware>();
app.UseMiddleware<ExceptionMiddleware>();
app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();