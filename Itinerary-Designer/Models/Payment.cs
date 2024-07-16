namespace Trips.Models
{
    public class PaymentModel
    {
        public string? UserId { get; set; }
        public string CreditCardNumber { get; set; }
        public string ExpirationDate { get; set; } // MM/YY or MM/YYYY format
        public string CVV { get; set; }

        public PaymentModel() {}

        public PaymentModel(string userId, string creditCardNumber, string expirationDate, string cVV)
        {
            UserId = userId;
            CreditCardNumber = creditCardNumber;
            ExpirationDate = expirationDate;
            CVV = cVV;
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
