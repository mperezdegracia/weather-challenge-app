namespace Application.Queries.CityWeather;
using MediatR;
using Core.Entities;


public class GetHistoryQuery : IRequest<IEnumerable<CityWeather>>
{

}
