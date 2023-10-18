using Application.Repositories;
using Domain;
using MediatR;

namespace Application.Queries
{
    public class GetWeatherForecastQuery : IRequest<IEnumerable<WeatherForecast>> { }

    public class GetWeatherForecastQueryHandler : IRequestHandler<GetWeatherForecastQuery, IEnumerable<WeatherForecast>>
    {
        private readonly ISummaryRepository _summaryRepository;

        public GetWeatherForecastQueryHandler(ISummaryRepository summaryRepository)
            => _summaryRepository = summaryRepository;

        public Task<IEnumerable<WeatherForecast>> Handle(GetWeatherForecastQuery request, CancellationToken cancellationToken)
        {
            var summaries = _summaryRepository
                .GetAllSummaries()
                .Select(summary => summary.Description)
                .ToArray();

            var weatherForecasts = Enumerable.Range(1, 5).Select(index => new WeatherForecast
            {
                Date = DateOnly.FromDateTime(DateTime.Now.AddDays(index)),
                TemperatureC = Random.Shared.Next(-20, 55),
                Summary = summaries[Random.Shared.Next(summaries.Length)]
            });

            return Task.FromResult(weatherForecasts);
        }
    }
}
