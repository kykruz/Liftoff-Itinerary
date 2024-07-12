using System.Runtime.Serialization;

// [DataContract]
public class ExchangeRateDTO
{
    // [DataMember(Name = "base")]
    public string? BaseCurrency { get; set; }
    
    // [DataMember(Name = "date")]
    public DateTime Date { get; set; }
    
    // [DataMember(Name = "rates")]
    public Dictionary<string, decimal>? Rates { get; set; }
}
