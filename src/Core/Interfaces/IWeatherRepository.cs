namespace Core.Interfaces;
using Core.Entities;

public interface IWeatherRepository
{

    Task<IEnumerable<CityWeather>> GetHistoryAsync();
    Task<CityWeather> GetAsync(string city);
    Task AddToHistory(CityWeather search);

}
