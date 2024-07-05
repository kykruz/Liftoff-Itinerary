using Itineraries.Models;
using LocationDatay.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreateItinerary.ViewModel;

public class CreateItineraryViewModel
{
    public string Name { get; set; }
    public List<SelectListItem>? LocationDatas { get; set; }
    public List<int> SelectedId {get; set;}
    public List<LocationData> AvailableLocations {get; set;}

    public CreateItineraryViewModel(List<LocationData> availableLocations)
    {
      
        AvailableLocations = availableLocations;
      
        //  LocationDatas = new List<SelectListItem>();

        //     foreach (var location in locationDatas)
        //     {
        //         LocationDatas.Add(
        //             new SelectListItem
        //             {
        //                 Value = location.Id.ToString(),
        //                 Text = location.Name
        //             }
        //         ); ;
        //     }

    }
    
}
