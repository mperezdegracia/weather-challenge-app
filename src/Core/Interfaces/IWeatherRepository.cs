using Core.Entities;

namespace Core.Interfaces;

public interface IWeatherRepository
{

    Task<IEnumerable<CityWeather>> GetHistoryAsync();
    Task<CityWeather> GetAsync(string city);
    Task AddToHistory(CityWeather search);

}
