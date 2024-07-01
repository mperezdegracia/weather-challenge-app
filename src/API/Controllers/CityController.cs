
using System;
using System.Diagnostics.CodeAnalysis;
using System.Threading.Tasks;
using API.Dtos;
using Core.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace API.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CityController : ControllerBase
{
    private readonly ICityService _cityService;


    public CityController(ICityService cityService)
    {
        _cityService = cityService;
    }

    [HttpGet]
    public async Task<IActionResult> GetAllCities()
    {
        var result = await _cityService.GetAllAsync();
        return Ok(result);
    }

    [HttpPost]

    public async Task<IActionResult> AddCity([FromBody]CityDto city)
    {
        //  TODO: implement special Exceptions and handle HTTP responses
        try
        {
            await _cityService.AddAsync(city.Name);
        }
        catch (Exception e)
        {

            return BadRequest(e.Message);
        }
        return Ok(new { message = "City added successfully." });
    }

    [HttpDelete("{id}")]

    public async Task<IActionResult> RemoveCity(int id)
    {
        //  TODO: implement special Exceptions and handle HTTP responses

        try
        {
            await _cityService.RemoveAsync(id);

        }
        catch (Exception e)
        {
            return BadRequest(e.Message);
        }
        return Ok();
    }




}