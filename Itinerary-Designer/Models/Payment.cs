public class PaymentModel
{
    public string? UserId { get; set; }
    public int CreditCardNumber { get; set; }
    public int ExpirationDate { get; set; }
    public int CVV { get; set; }
   
    public PaymentModel() {}

    public PaymentModel(string userId, int creditCardNumber, int expirationDate, int cVV)
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