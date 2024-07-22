using Newtonsoft.Json;

public class ConvertResponse
{
    [JsonProperty("result")]
    public decimal ConvertedAmount { get; set; }

}
