using Core.Interfaces;
using MediatR;

namespace Application.Commands.CityWeather;

public class AddToHistoryCommandHandler : IRequestHandler<AddToHistoryCommand>
{

     private readonly IWeatherRepository _weatherRepository;

        public AddToHistoryCommandHandler(IWeatherRepository weatherRepository)
        {
            _weatherRepository = weatherRepository ?? throw new ArgumentNullException(nameof(weatherRepository));
        }

        public async Task<Unit> Handle(AddToHistoryCommand request, CancellationToken cancellationToken)
        {
            // Logic to save CityWeather to the repository
            await _weatherRepository.AddToHistory(request.CityWeather);
            return Unit.Value;
        }
}
