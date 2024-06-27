using System;
using System.Threading.Tasks;
using Application.Queries.CityWeather;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class WeatherController : ControllerBase
{
    private readonly IMediator _mediator;


    public WeatherController(IMediator mediator)
    {
        _mediator = mediator;
    }


    [HttpGet("{city}")]

    public async Task<IActionResult> GetWeather(string city)
    {
        var result = await _mediator.Send(new GetCityWeatherQuery(city));
        return Ok(result);
    }

    [HttpGet("history")]

    public async Task<IActionResult> GetHistory()
    {
        var result = await _mediator.Send(new GetHistoryQuery());
        return Ok(result);
    }


}
