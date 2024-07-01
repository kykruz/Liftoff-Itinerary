namespace Itinerary.Models;

public class LocationData
{

    public int Id { get; set; }
    public string Name { get; set; }
    public string Address { get; set; }
    
    public LocationData(int id, string name, string address)
    {
        Id = id;
        Name = name;
        Address = address;
    }

}

