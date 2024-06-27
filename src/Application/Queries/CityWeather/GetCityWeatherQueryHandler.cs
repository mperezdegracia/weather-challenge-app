namespace Application.Queries.CityWeather;

using MediatR;
using Core.Entities;
using System.Threading.Tasks;
using System.Threading;
using Core.Interfaces;

public class GetCityWeatherQueryHandler : IRequestHandler<GetCityWeatherQuery, CityWeather>
{

    private readonly IWeatherRepository _weatherRepository;

    public GetCityWeatherQueryHandler(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    public Task<CityWeather> Handle(GetCityWeatherQuery request, CancellationToken cancellationToken)
    {


        return _weatherRepository.GetAsync(request.City);
    }
}
