using Application.Commands.CityWeather;
using Application.Queries.CityWeather;
using Core.Entities;
using Core.Interfaces;
using MediatR;
namespace Application;

public class WeatherService : IWeatherService
{
    private readonly IMediator _mediator;

    public WeatherService(IMediator mediator)
    {
        _mediator = mediator;
    }

    public async Task AddToHistoryAsync(CityWeather weather)
    {
        var command = new AddToHistoryCommand(weather);
        await _mediator.Send(command);
    }

    public async Task<CityWeather> GetAndSaveAsync(string city)
    {
        var weather = await GetAsync(city);
        await AddToHistoryAsync(weather);

        return weather;
    }

    public async Task<CityWeather> GetAsync(string city)
    {
        var query = new GetCityWeatherQuery(city);
        var weather = await _mediator.Send(query);

        return weather;
    }

    public async Task<IEnumerable<CityWeather>> GetHistoryAsync()
    {
        var query = new GetHistoryQuery();
        return await _mediator.Send(query);
    }
}
