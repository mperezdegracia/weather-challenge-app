
namespace Core.Interfaces;

using Core.Entities;
public interface IWeatherService
{
    Task<CityWeather> GetAndSaveAsync(string city);
    Task<CityWeather> GetAsync(string city);

    Task<IEnumerable<CityWeather>> GetHistoryAsync();
    Task AddToHistoryAsync(CityWeather weather);

}
