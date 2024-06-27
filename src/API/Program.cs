using System;
using System.Net.Http;
using Application;
using Application.Commands.CityWeather;
using Application.Queries.CityWeather;
using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


var builder = WebApplication.CreateBuilder(args);

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true);


// Add services to the container.
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddHttpClient("WeatherAPI", client =>
{
    client.BaseAddress = new Uri("https://api.openweathermap.org");
    client.DefaultRequestHeaders.Add("Accept", "application/json");
});

// MediaTr
builder.Services.AddMediatR(typeof(AddToHistoryCommand).Assembly);



// Configure DbContext
builder.Services.AddDbContext<WeatherDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddSingleton(builder.Configuration);

// Add Angular files to be served by the app
builder.Services.AddSpaStaticFiles(configuration =>
{
    configuration.RootPath = "./Client/dist";
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
else
{
    app.UseExceptionHandler("/Error");
    app.UseHsts();
}

app.UseHttpsRedirection();

// app.UseSpaStaticFiles();
app.UseRouting();
app.MapControllers();


// app.UseSpa(spa =>
// {
//     spa.Options.SourcePath = "./Client";

//     // if (app.Environment.IsDevelopment())
//     // {
//     //     spa.UseProxyToSpaDevelopmentServer("http://localhost:4200");
//     // }
// });

app.Run();
