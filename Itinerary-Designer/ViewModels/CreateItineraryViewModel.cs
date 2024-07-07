using Trips.Models;

public class CreateItineraryViewModel
{
    public string Name { get; set; }
    public List<LocationData> AvailableLocations { get; set; } // List of available locations
    public List<int> SelectedLocationIds { get; set; } // Selected location IDs

    public CreateItineraryViewModel()
    {
        AvailableLocations = new List<LocationData>();
        SelectedLocationIds = new List<int>();
    }
}
