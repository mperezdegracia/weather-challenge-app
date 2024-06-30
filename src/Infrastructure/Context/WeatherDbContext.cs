using Core.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context;

public class WeatherDbContext : DbContext
{
    public WeatherDbContext(DbContextOptions<WeatherDbContext> options) : base(options)
    {
    }

    public DbSet<City> Cities { get; set; }
    public DbSet<CityWeather> CityWeathers { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        modelBuilder.Entity<City>()
            .HasIndex(c => new { c.Name, c.Country })
            .IsUnique();
    }



}
