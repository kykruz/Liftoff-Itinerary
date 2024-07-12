// using Exchange.Services;

// public class ExchangeService
// {
//     private readonly ExchangeRatesApiService client;

//     public ExchangeService()
//     {
//         client = new ExchangeRatesApiService();
//     }

//     public async Task<decimal> ConvertCurrencyAsync(string fromCurrency, string toCurrency, decimal amount)
//     {
//         try
//         {
//             var exchangeRates = await client.GetExchangeRatesAsync(fromCurrency);

//             if (exchangeRates.Rates.TryGetValue(toCurrency, out var rate))
//             {
//                 return amount * rate;
//             }
//             else
//             {
//                 throw new Exception($"Exchange rate not found for {toCurrency}");
//             }
//         }
//         catch (Exception ex)
//         {
//             // Handle exceptions or log them appropriately
//             throw;
//         }
//     }
// }
