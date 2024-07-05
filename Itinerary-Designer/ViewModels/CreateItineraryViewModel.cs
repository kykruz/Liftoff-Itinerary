using Itinerary.Models;

namespace CreateItinerary.ViewModel;

public class CreateItineraryViewModel
{
    public int Id { get; set; }
    private static int nextId = 1;
    public string Name { get; set; }
    public List<LocationData> LocationDatas { get; set; }

    public CreateItineraryViewModel()
    {

    }
    
}
