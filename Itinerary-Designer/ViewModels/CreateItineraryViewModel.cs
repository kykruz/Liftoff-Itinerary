using Microsoft.AspNetCore.Authorization.Infrastructure;
using Microsoft.AspNetCore.Mvc.Rendering;
using NuGet.Common;
using Trips.Models;

namespace Trips.ViewModel;

public class CreateItineraryViewModel
{
    public string? Name { get; set; }
    public List<int>? LocationIds { get; set; }
    public DateTime Date { get; set; }
    //Made these null - Jak

    public CreateItineraryViewModel(DateTime date, string name, List<int> locationids)
    {
        LocationIds = locationids;
        Date = date;
        Name = name;
    }

    public CreateItineraryViewModel() { }
}