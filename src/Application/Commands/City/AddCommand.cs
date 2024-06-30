
namespace Application.Commands.City;

using MediatR;
using Core.Entities;


public class AddCommand(string city, string country): IRequest
{
    public string CityName { get; set; } = city;
    public string Country { get; set; } = country;
}