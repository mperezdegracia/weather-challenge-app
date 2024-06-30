
namespace Core.Interfaces;

using Core.Entities;
public interface IWeatherService
{
    Task<CityWeather> GetAsync(string city);
    Task<IEnumerable<CityWeather>> GetHistoryAsync();
    Task AddToHistoryAsync(CityWeather weather);

}
