
namespace Core.Interfaces;

using Core.Entities;
public interface ICityService
{
    Task<IEnumerable<City>> GetAllAsync();
    Task AddAsync(string city);
    Task RemoveAsync(int id);
    
}
