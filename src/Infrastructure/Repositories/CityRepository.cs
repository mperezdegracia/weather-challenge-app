namespace Infrastructure.Repositories;
using Infrastructure.Context;
using System.Net.Http;
using System.Text.Json;
using Microsoft.Extensions.Configuration;
using Core.Interfaces;
using System.Threading.Tasks;
using Core.Entities;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;

public class CityRepository : ICityRepository
{
    private readonly WeatherDbContext _context;

    public CityRepository(WeatherDbContext context)
    {
        _context = context;
    }

    public async Task AddCity(string city, string country)
    {
          var cityObj = new City
        {
            Name = city,
            Country = country
        };
        
        _context.Cities.Add(cityObj);
        try
        {
            await _context.SaveChangesAsync();
        }
        catch (DbUpdateException) 
        {
            // Handle the case where the city already exists
            throw new Exception("City already exists.");
        }
    }

    public async Task<IEnumerable<City>> GetAllAsync()
    {
        return await _context.Cities.ToListAsync();
    }

    public async Task RemoveCity(int id)
    {

        var city = await _context.Cities.FindAsync(id);
        if (city != null)
        {
            _context.Cities.Remove(city);
            await _context.SaveChangesAsync();
        }        
       
    }
}
