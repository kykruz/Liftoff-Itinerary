using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Common;
using Trips.Models;

namespace Trips.ViewModel;

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
