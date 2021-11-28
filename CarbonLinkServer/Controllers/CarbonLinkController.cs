using Microsoft.AspNetCore.Mvc;

namespace CarbonLinkServer.Controllers;

[ApiController]
[Route("[controller]")]
public class CarbonLinkController : ControllerBase
{
    private readonly ILogger<CarbonLinkController> _logger;

    public CarbonLinkController(ILogger<CarbonLinkController> logger)
    {
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public IEnumerable<WeatherForecast> Get()
    {
        return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        {
            Date = DateTime.Now.AddDays(index),
            TemperatureC = Random.Shared.Next(-20, 55),
        })
        .ToArray();
    }
}
