using Microsoft.EntityFrameworkCore;
using StokTakipAPI.Business;
using StokTakipAPI.DataAccess;
using StokTakipAPI.DataAccess.Context;
using System.Reflection;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(Assembly.GetExecutingAssembly());

// Repository and Veri Tabaný Baðlantýsý
builder.Services.AddDataAccessDependencies(builder.Configuration);

// Service ve Rules 
builder.Services.AddDataBusinessDependencies();


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
