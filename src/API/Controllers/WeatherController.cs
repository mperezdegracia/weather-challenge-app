using System.Threading.Tasks;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
     private readonly IWeatherService _weatherService;


    public WeatherController(IWeatherService weatherService)
    {
        _weatherService = weatherService;
    }


    [HttpGet("{city}")]

    public async Task<IActionResult> GetWeather(string city)
    {
        var result = await _weatherService.GetAndSaveAsync(city);
        return Ok(result);
    }

    [HttpGet("history")]

    public async Task<IActionResult> GetHistory()
    {
        var result = await _weatherService.GetHistoryAsync();
        return Ok(result);
    }


}
