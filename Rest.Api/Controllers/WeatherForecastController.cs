using Application.Queries;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Rest.Api.Controllers;

[ApiController]
[Route("[controller]")]
public class WeatherForecastController : ControllerBase
{


    private readonly IMediator _mediator;
    private readonly ILogger<WeatherForecastController> _logger;

    public WeatherForecastController(IMediator mediator, ILogger<WeatherForecastController> logger)
    {
        _mediator = mediator;
        _logger = logger;
    }

    [HttpGet(Name = "GetWeatherForecast")]
    public async Task<IEnumerable<WeatherForecast>> Get()
    {
        var forecasts = await _mediator.Send(new GetWeatherForecastQuery());
        return forecasts.Select(domainForecast => new WeatherForecast
        {
            Summary = domainForecast.Summary,
            Date = domainForecast.Date,
            TemperatureC = domainForecast.TemperatureC
        });
    }
}
