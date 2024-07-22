namespace Trips.Models;
   
public class ConvertRequest
{
    public string FromCurrency { get; set; }
    public string ToCurrency { get; set; }
    public decimal Amount { get; set; }

    public ConvertRequest(){}
    public ConvertRequest(string fromCurrency, string toCurrency, decimal amount): this()
    {
        FromCurrency = fromCurrency;
        ToCurrency = toCurrency;
        Amount = amount;
    }

}
