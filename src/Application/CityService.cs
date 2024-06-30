using Application.Commands.City;
using Application.Queries.City;
using Core;
using Core.Entities;
using Core.Exceptions;
using Core.Interfaces;
using MediatR;
using Microsoft.EntityFrameworkCore;

namespace Application;




public class CityService : ICityService
{

    private readonly IMediator _mediator;

    private readonly IWeatherService _weatherService;



    public CityService(IMediator mediator, IWeatherService weatherService)
    {
        _weatherService = weatherService;
        _mediator = mediator;
    }

    public Task AddAsync(string city)
    {
        // want to check if the external api has the city
        CityWeather weather;
        try
        {
             weather = _weatherService.GetAsync(city).Result;
        }
        catch (WeatherNotFound)
        {
            throw new CityNotFound();

        }

        var command = new AddCommand(city, weather.Country);
        return _mediator.Send(command);
    }
    public Task<IEnumerable<City>> GetAllAsync()
    {
        var query = new GetAllQuery();
        return _mediator.Send(query);
    }

    public Task RemoveAsync(int id)
    {
        var command = new RemoveCommand(id);
        return _mediator.Send(command);
    }


}
