



using Application.Commands.City;
using Core.Entities;
using Core.Interfaces;
using MediatR;

public class AddCommandHandler : IRequestHandler<AddCommand>
{

    private readonly ICityRepository _cityRepository;

    public AddCommandHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
    }
    public async Task<Unit> Handle(AddCommand request, CancellationToken cancellationToken)
    {
        await _cityRepository.AddCity(request.CityName, request.Country);
        return Unit.Value;
    }   
}
