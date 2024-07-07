using Trips.Models;

public class CreateItineraryViewModel
{
    public string Name { get; set; }
    public List<LocationData> AvailableLocations { get; set; } 
    public List<int> SelectedLocationIds { get; set; } 

    public CreateItineraryViewModel()
    {
        AvailableLocations = new List<LocationData>();
        SelectedLocationIds = new List<int>();
    }
}