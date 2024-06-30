
namespace Application.Queries.City;

using Core.Entities;
using Infrastructure.Repositories;
using MediatR;

public class GetAllQuery : IRequest<IEnumerable<City>>
{
    
}