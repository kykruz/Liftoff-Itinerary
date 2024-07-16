using System;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Trips.Models;

namespace Exchange.Services
{
    public class ExchangeRatesApiService
    {
        private readonly HttpClient _httpClient;
        private readonly string _apiKey = "osBudYFRdkNVt6966P10CnRGMpEDIZK3";
        private readonly string _baseUrl = "https://api.exchangeratesapi.io/";

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

        public async Task<ProcessPayment> ProcessPaymentAsync(PaymentModel payment)
        {
            try
            {
                // Example: Simulate API call to process payment
                // Replace with actual API endpoint and logic
                var url = $"{_baseUrl}/processPayment";
                var jsonContent = JsonConvert.SerializeObject(payment);
                var content = new StringContent(jsonContent, Encoding.UTF8, "application/json");

                var response = await _httpClient.PostAsync(url, content);

                response.EnsureSuccessStatusCode(); // Throw if HTTP error

                var responseBody = await response.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<ProcessPayment>(responseBody);

                return result;
            }
            catch (HttpRequestException ex)
            {
                // Log the exception and handle it gracefully
                Console.WriteLine($"HTTP Request Error: {ex.Message}");
                return new ProcessPayment { Success = false };
            }
            catch (Exception ex)
            {
                // Log the exception and handle it gracefully
                Console.WriteLine($"Error processing payment: {ex.Message}");
                return new ProcessPayment { Success = false };
            }
        }
    }

    public class ProcessPayment
    {
        public bool Success { get; set; }
        // Add more properties as needed for detailed response handling
    }
}
