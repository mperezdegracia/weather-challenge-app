
namespace Application.Queries.CityWeather;

using MediatR;
using Core.Entities;

public class GetCityWeatherQuery : IRequest<CityWeather>
{

    public string City { get; set; }
    public GetCityWeatherQuery(string city)
    {
        this.City = city;
    }
}
