using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace ServiceNoticias
{
    public class AlphaVantageWorker : BackgroundService
    {
        private readonly IServiceProvider _serviceProvider;

        public AlphaVantageWorker(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
        }

        protected override async Task ExecuteAsync(CancellationToken stoppingToken)
        {
            while (!stoppingToken.IsCancellationRequested)
            {
                try
                { 
                    string apiKey = "CE1E1UB2O97OH9WF";
                    string ticker = "AAPL"; 

                    using (var scope = _serviceProvider.CreateScope())
                    {
                        var apiManager = scope.ServiceProvider.GetRequiredService<AlphaVantageApiManager>();
                        var jsonData = await apiManager.GetNewsSentimentAsync(apiKey, ticker);

                        if (!jsonData.ToString().Equals("rate limit is 25 requests per day"))
                        {

                            await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                        }

                        // Introducir un retardo o controlar la frecuencia de tus solicitudes
                        await Task.Delay(TimeSpan.FromMinutes(1), stoppingToken);
                    }
                }
                catch (Exception ex)
                {
                    Console.WriteLine($"Error in ExecuteAsync: {ex.Message}");
                }
            }
        }
    }
}
