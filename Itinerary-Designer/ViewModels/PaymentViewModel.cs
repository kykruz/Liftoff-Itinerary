using Trips.Models;

public class Payment
{
    public string? UserId { get; set; }
    public int CreditCardNumber { get; set; }
    public int ExpirationDate { get; set; }
    public int CVV { get; set; }
   
   public Payment() {}
}

