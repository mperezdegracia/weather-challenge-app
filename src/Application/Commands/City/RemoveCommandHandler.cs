



using Application.Commands.City;
using Core.Entities;
using Core.Interfaces;
using MediatR;

public class RemoveCommandHandler : IRequestHandler<RemoveCommand>
{

    private readonly ICityRepository _cityRepository;

    public RemoveCommandHandler(ICityRepository cityRepository)
    {
        _cityRepository = cityRepository ?? throw new ArgumentNullException(nameof(cityRepository));
    }
    public async Task<Unit> Handle(RemoveCommand request, CancellationToken cancellationToken)
    {
        await _cityRepository.RemoveCity(request.Id);
        return Unit.Value;
    }   
}
