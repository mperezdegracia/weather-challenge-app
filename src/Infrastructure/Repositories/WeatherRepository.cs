namespace Infrastructure.Repositories;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System.Net.Http;
using System;
using System.Text.Json;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using Infrastructure.Dtos;

public class WeatherRepository : IWeatherRepository
{
    private readonly WeatherDbContext _context;
    private readonly IHttpClientFactory _httpClientFactory;
    private readonly IConfiguration _configuration;
    private readonly JsonSerializerOptions _jsonOptions;

    public WeatherRepository(WeatherDbContext context, IHttpClientFactory httpClientFactory, IConfiguration configuration)
    {
        _context = context;
        _httpClientFactory = httpClientFactory;
        _configuration = configuration;
        _jsonOptions = new JsonSerializerOptions
        {
            PropertyNamingPolicy = JsonNamingPolicy.CamelCase
        };

    }


    public async Task AddToHistory(CityWeather search)
    {
        _context.CityWeathers.Add(search);
        await _context.SaveChangesAsync();
    }

    public async Task<CityWeather> GetAsync(string city)
    {
        var client = _httpClientFactory.CreateClient("WeatherAPI");
        var apiKey = _configuration["WeatherApi:ApiKey"];
        var response = await client.GetAsync($"/data/2.5/weather?q={city}&appid={apiKey}");

        if (response.IsSuccessStatusCode)
        {
            var content = await response.Content.ReadAsStringAsync();
            var externalWeather = JsonSerializer.Deserialize<WeatherData>(content, _jsonOptions);

            if (externalWeather != null)
            {
                var cityWeather = new CityWeather
                {
                    City = externalWeather.Name,
                    Country = externalWeather.Sys.Country,
                    Temperature = externalWeather.Main.Temp,
                    FeelsLike = externalWeather.Main.FeelsLike
                };

                return cityWeather;
            }
            else
            {
                throw new Exception("Deserialization returned null.");
            }
        }
        else
        {
            throw new Exception($"Failed to get weather data: {response.StatusCode}");
        }
    }

    public async Task<IEnumerable<CityWeather>> GetHistoryAsync()
    {
        return await _context.CityWeathers.ToListAsync();
    }
}
