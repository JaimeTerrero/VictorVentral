using Microsoft.EntityFrameworkCore;
using VictorVentral.Customers.Infrastructure.Persistence.Context;
using VictorVentral.Customers.Infrastructure.IoC;
using VictorVentral.Customers.Application.IoC;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<CustomersDbContext>(opt =>
    opt.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

// Add services to the container
builder.Services
    .AddRepositories()
    .AddServices();

// For the AutoMapper Configuration
var mapperAssembly = Assembly.Load("VictorVentral.Customers.Infrastructure");
builder.Services.AddAutoMapper(mapperAssembly);

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
