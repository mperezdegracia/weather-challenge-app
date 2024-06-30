

namespace Application.Commands.City;

using MediatR;
using Core.Entities;


public class RemoveCommand(int id): IRequest
{
    public int Id { get; set; } = id;
}