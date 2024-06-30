
namespace Application.Queries.City;

using System.Threading;
using System.Threading.Tasks;
using Core.Entities;
using Core.Interfaces;
using Infrastructure.Repositories;
using MediatR;

public class GetAllQueryHandler : IRequestHandler<GetAllQuery, IEnumerable<City>>
{

    private readonly ICityRepository _repository;

    public GetAllQueryHandler(ICityRepository repository)
    {
        _repository = repository;
    }


    public async Task<IEnumerable<City>> Handle(GetAllQuery request, CancellationToken cancellationToken)
    {
        return await _repository.GetAllAsync();
    }
}