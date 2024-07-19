using Microsoft.AspNetCore.Mvc;
using System;
using System.Threading.Tasks;
using Exchange.Services;

namespace Exchange.Controllers
{
    public class CurrencyController : Controller
    {
        private readonly ExchangeRatesApiService _exchangeRatesApi;

        public CurrencyController(ExchangeRatesApiService exchangeRatesApi)
        {
            _exchangeRatesApi = exchangeRatesApi;
        }

        [HttpGet("currency")]
        public async Task<IActionResult> ConvertCurrency(string fromCurrency, string toCurrency, double amount)
        {
            /*try
            {
                var request = new ConvertRequest(fromCurrency, toCurrency, amount);
                var response = await _exchangeRatesApi.ConvertAsync(request);

                // Preparing data to pass to the View
                ViewData["Amount"] = amount;
                ViewData["FromCurrency"] = fromCurrency;
                ViewData["ToCurrency"] = toCurrency;
                ViewData["ConvertedAmount"] = response.Result;

                return View("Index");
            }
            catch (Exception ex)
            {
                ViewData["Error"] = ex.Message;
                return View("Index");
            }*/
            using (var httpClient = new HttpClient())
        {
        string apiUrl = $"https://api.apilayer.com/exchangerates_data/convert?to={toCurrency}&from={fromCurrency}&amount={amount}";
        var request = new HttpRequestMessage(HttpMethod.Get, apiUrl);

    
        request.Headers.Add("apikey", "osBudYFRdkNVt6966P10CnRGMpEDIZK3");
        try
        {
            HttpResponseMessage response = await httpClient.SendAsync(request);


            if (response.IsSuccessStatusCode)
            {
                string json = await response.Content.ReadAsStringAsync();

                return Ok(json);
            }
            else
            {
                return StatusCode(
                    (int)response.StatusCode,
                    "Error fetching data from external API"
                );
            }
        }
        catch (Exception ex)
        {
            return StatusCode(500, $"Internal server error: {ex.Message}");
        }
        }
        }
    }
}

