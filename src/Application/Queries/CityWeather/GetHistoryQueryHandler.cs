
namespace Application.Queries.CityWeather;

using MediatR;
using Core.Entities;
using System.Threading.Tasks;
using System.Threading;
using Core.Interfaces;

public class GetHistoryQueryHandler : IRequestHandler<GetHistoryQuery, IEnumerable<CityWeather>>
{

    private readonly IWeatherRepository _weatherRepository;

    public GetHistoryQueryHandler(IWeatherRepository weatherRepository)
    {
        _weatherRepository = weatherRepository;
    }

    public Task<IEnumerable<CityWeather>> Handle(GetHistoryQuery request, CancellationToken cancellationToken)
    {
        return _weatherRepository.GetHistoryAsync();

    }
}
