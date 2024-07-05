using Itineraries.Models;
using LocationDatay.Models;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace CreateItinerary.ViewModel;

public class CreateItineraryViewModel
{
    public int Id { get; set; }
    private static int nextId = 1;
    public string Name { get; set; }
    public List<SelectListItem>? LocationDatas { get; set; }

    public CreateItineraryViewModel(List<LocationData> locationDatas)
    {
         LocationDatas = new List<SelectListItem>();

            foreach (var location in locationDatas)
            {
                LocationDatas.Add(
                    new SelectListItem
                    {
                        Value = location.Id.ToString(),
                        Text = location.Name
                    }
                ); ;
            }

    }
    
}
