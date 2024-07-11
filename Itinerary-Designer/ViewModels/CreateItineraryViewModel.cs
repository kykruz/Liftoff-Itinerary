using System;
using System.Collections.Generic;
using Trips.Models;

public class CreateItineraryViewModel
{
    public string Name { get; set; }
    public DateTime Date { get; set; }
    public List<LocationData> AvailableLocations { get; set; }
    public List<int> SelectedLocationIds { get; set; }
    public List<string> AvailableCategories { get; set; }
    public List<string> SelectedCategories { get; set; }
    public int NumberOfPeople { get; set; }
    public decimal TotalCost { get; set; }
    public decimal TotalCostForAllPeople { get; set; }

    public CreateItineraryViewModel()
    {
        AvailableLocations = new List<LocationData>();
        SelectedLocationIds = new List<int>();
        AvailableCategories = new List<string>();
        SelectedCategories = new List<string>();
    }
}
