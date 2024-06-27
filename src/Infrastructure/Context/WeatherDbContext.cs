using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class WeatherDbContext : DbContext
{
    public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
    {
    }

    public DbSet<CityWeather> CityWeathers { get; set; }

}
