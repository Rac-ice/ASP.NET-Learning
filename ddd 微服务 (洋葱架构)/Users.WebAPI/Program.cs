using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Serilog;
using Serilog.Formatting.Json;
using System.Reflection;
using Users.Domain.DomainServices;
using Users.Domain.IAntis;
using Users.Domain.IRepositories;
using Users.Infrastructure.Anti;
using Users.Infrastructure.DbContexts;
using Users.Infrastructure.Repositories;
using Users.WebAPI.UnitOfWork;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// Logging
builder.Services.AddLogging(log =>
{
    Log.Logger = new LoggerConfiguration()
    .MinimumLevel.Information()
    .Enrich.FromLogContext()
    .WriteTo.Console(new JsonFormatter())
    .CreateLogger();
    log.AddSerilog();
});

// DbContext
builder.Services.AddDbContext<UserDbContext>(options =>
{
    ConfigurationBuilder configurationBuilder = new ConfigurationBuilder();
    configurationBuilder.AddEnvironmentVariables();
    var configuration = configurationBuilder.Build();
    options.UseSqlServer(configuration["ConnectionString"]);
});

// RedisCache
builder.Services.AddStackExchangeRedisCache(options =>
{
    options.Configuration = "localhost";
    options.InstanceName = "UsersDemo_";
});

// Filter
builder.Services.Configure<MvcOptions>(opt =>
{
    opt.Filters.Add<UnitOfWorkFilter>();
});

// DomainServices
builder.Services.AddScoped<UserDomainService>();

// Antis
builder.Services.AddScoped<ISmsCodeSender, MockSmsCodedSender>();

// Repositories
builder.Services.AddScoped<IUserDomainRepository, UserRepository>();

// MediatR
builder.Services.AddMediatR(config=>config.RegisterServicesFromAssembly(Assembly.GetExecutingAssembly()));

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
