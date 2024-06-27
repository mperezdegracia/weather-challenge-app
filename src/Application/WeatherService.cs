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

    public Task<CityWeather> GetAsync(string city)
    {
        var query = new GetCityWeatherQuery(city);
        return _mediator.Send(query);

    }

    public async Task<IEnumerable<CityWeather>> GetSearchHistoryAsync()
    {
        var query = new GetHistoryQuery();
        return await _mediator.Send(query);
    }
}
