using System.Net.Http;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Exchange.Services
{
    public class ExchangeRatesApiService : ControllerBase
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "osBudYFRdkNVt6966P10CnRGMpEDIZK3";
        
        private readonly string _baseUrl = "https://api.apilayer.com/exchangerates_data";
//         https://api.apilayer.com/exchangerates_data/convert?to={to}&from={from}&amount={amount}");
// client.Timeout = -1;

        public ExchangeRatesApiService()
        {
            _httpClient = new HttpClient();
        }

        public async Task<ConvertResponse> ConvertAsync(ConvertRequest request)
        {
            var url = $"{_baseUrl}/convert?from={request.FromCurrency}&to={request.ToCurrency}&amount={request.Amount}&apiKey={_apiKey}";
            var response = await _httpClient.GetStringAsync(url);
            return JsonConvert.DeserializeObject<ConvertResponse>(response);
        }
    }

    public class ConvertRequest
    {
        public string FromCurrency { get; set; }
        public string ToCurrency { get; set; }
        public double Amount { get; set; }

        public ConvertRequest(string fromCurrency, string toCurrency, double amount)
        {
            FromCurrency = fromCurrency;
            ToCurrency = toCurrency;
            Amount = amount;
        }
    }

    public class ConvertResponse
    {
        public double Result { get; set; }
    }
    
}