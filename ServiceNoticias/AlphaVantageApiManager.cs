
namespace ServiceNoticias
{
    using System;
    using System.Collections.Generic;
    using System.Net.Http;
    using System.Text.Json;
    using System.Threading.Tasks;

    public class AlphaVantageApiManager
    {
        private readonly HttpClient _httpClient;

        public AlphaVantageApiManager()
        {
            _httpClient = new HttpClient();
        }

        public async Task<dynamic> GetNewsSentimentAsync(string apiKey, string ticker)
        {
            try
            {
                string queryUrl = $"https://www.alphavantage.co/query?function=NEWS_SENTIMENT&tickers={ticker}&apikey={apiKey}";
                string jsonResult = await _httpClient.GetStringAsync(new Uri(queryUrl));

               return jsonResult;
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error in GetNewsSentimentAsync: {ex.Message}");
                return null;
            }
        }
    }



}
