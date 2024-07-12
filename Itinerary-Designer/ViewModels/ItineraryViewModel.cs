using System.Collections.Generic;
using Trips.ViewModels;
using Trips.Models;
using System.ComponentModel.DataAnnotations;
public class ItineraryViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int NumberOfPeople { get; set; }
    public int NumberOfPets { get; set; }
}
