
namespace Core.Interfaces;

using Core.Entities;
public interface IWeatherService
{
    Task<CityWeather> GetAsync(string city);
    Task<IEnumerable<CityWeather>> GetSearchHistoryAsync();

    Task AddToHistoryAsync(CityWeather weather);

}
