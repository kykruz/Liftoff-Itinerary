using Trips.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class CreateItineraryViewModel
{
    [Required(ErrorMessage = "Name is required")]
    public string Name { get; set; }
    
    [Required(ErrorMessage = "Please select at least one location")]
    public List<int> SelectedLocationIds { get; set; } 
    
    [Required(ErrorMessage = "Date is required")]
    public DateTime Date {get; set;}
    
    public List<LocationData> AvailableLocations { get; set; } 
    

    public CreateItineraryViewModel()
    {
        AvailableLocations = new List<LocationData>();
        SelectedLocationIds = new List<int>();
    }
}
