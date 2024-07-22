using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using Trips.Models;
using RestSharp;

namespace Exchange.Services
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchangeRatesApiService : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "osBudYFRdkNVt6966P10CnRGMpEDIZK3";

        private readonly string _baseUrl = "https://api.apilayer.com/exchangerates_data";

        //         https://api.apilayer.com/exchangerates_data/convert?to={to}&from={from}&amount={amount}");
        // client.Timeout = -1;

        public ExchangeRatesApiService(HttpClient httpClient, IConfiguration configuration)
        {
            _httpClient = httpClient;
        }

        [HttpGet("convert")]
        public async Task<ConvertResponse> ConvertAsync(string fromCurrency, string toCurrency, double amount)
        {
        string apiUrl = $"{_baseUrl}/convert?to={toCurrency}&from={fromCurrency}&amount={amount}";
            var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);
            request.Headers.Add("apikey", _apiKey);

            HttpResponseMessage response = await _httpClient.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();
                return JsonConvert.DeserializeObject<ConvertResponse>(json);
            }
            else
            {
                throw new HttpRequestException($"Error fetching data from API: {response.ReasonPhrase}");
            }
        }
    
        //     var url =
        //         $"{_baseUrl}/convert?to={request.ToCurrency}&from={request.FromCurrency}&amount={request.Amount}&apiKey={_apiKey}";
        //     var response = await _httpClient.GetStringAsync(url);
        //     return JsonConvert.DeserializeObject<ConvertResponse>(response);

        // var client = new RestClient ($"{_baseUrl}/convert?to={request.ToCurrency}&from={request.FromCurrency}&amount={request.Amount}");
        // var restRequest = new RestRequest("convert", Method.Get);
        //     restRequest.AddQueryParameter("from", request.FromCurrency);
        //     restRequest.AddQueryParameter("to", request.ToCurrency);
        //     restRequest.AddQueryParameter("amount", request.Amount.ToString());
        //     restRequest.AddQueryParameter("apikey", _apiKey);
        //     restRequest.Timeout = TimeSpan.FromSeconds(10); 

        // RestResponse response = await client.ExecuteAsync(restRequest);
        // if(!response.IsSuccessful)
        // {
        //     throw new Exception($"Error fetching conversion data: {response.ErrorMessage}");
        // } 
        // return JsonConvert.DeserializeObject<ConvertResponse>(response.Content);



        }

        // [HttpGet("rate")]
        // public async Task<decimal> GetUsdToEurRateAsync()
        // {
        //     var url = $"{_baseUrl}/latest?symbols=EUR&base=USD&apikey={_apiKey}";
        //     var response = await _httpClient.GetStringAsync(url);
        //     var data = JsonConvert.DeserializeObject<ExchangeRateResponse>(response);
        //     return data.Rates["EUR"];
        // }

        public class ExchangeRateResponse
        {
            public Dictionary<string, decimal> Rates { get; set; }
        }
}



