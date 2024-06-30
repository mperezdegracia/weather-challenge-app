namespace Core.Interfaces;
using Core.Entities;

public interface ICityRepository
{

    Task<IEnumerable<City>> GetAllAsync();
    Task AddCity(string city, string country);
    Task RemoveCity(int id);


}
