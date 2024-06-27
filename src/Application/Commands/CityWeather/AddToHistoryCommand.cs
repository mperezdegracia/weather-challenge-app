namespace Application.Commands.CityWeather;
using MediatR;
using Core.Entities;
public class AddToHistoryCommand(CityWeather cityWeather) : IRequest 
{
    public CityWeather CityWeather { get; set; } = cityWeather;

}
