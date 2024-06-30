using System;
using Application;
using Application.Commands.City;
using Application.Commands.CityWeather;
using Core.Interfaces;
using Infrastructure.Context;
using Infrastructure.Repositories;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
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
builder.Services.AddScoped<IWeatherRepository, WeatherRepository>();
builder.Services.AddScoped<ICityRepository, CityRepository>();
builder.Services.AddScoped<ICityService, CityService>();
builder.Services.AddScoped<IWeatherService, WeatherService>();
builder.Services.AddSingleton(builder.Configuration);
builder.Services.AddMediatR(typeof(AddToHistoryCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(AddCommandHandler).Assembly);
builder.Services.AddMediatR(typeof(RemoveCommandHandler).Assembly);

builder.Services.AddCors(
    options =>
    {
        options.AddDefaultPolicy(
            builder =>
            {
                builder.AllowAnyOrigin() 
                    .AllowAnyMethod()
                    .AllowAnyHeader();
            });
    });
 // we can change this to only allow calls from Frontend
// Configure DbContext
builder.Services.AddDbContext<WeatherDbContext>(options => 
options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"), options =>
{
    options.EnableRetryOnFailure(); // Habilitar reintentos en caso de fallo
    options.MigrationsAssembly("Infrastructure");
}));

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
app.UseCors();
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
