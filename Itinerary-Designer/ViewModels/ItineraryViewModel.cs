using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Trips.Models;
using Trips.ViewModels;

public class ItineraryViewModel
{
    public string Title { get; set; }
    public string Description { get; set; }
    public string ImageUrl { get; set; }
    public int NumberOfPeople { get; set; }
    public int NumberOfPets { get; set; }

    public double Latitude { get; set; }
    public double Longitude { get; set; }
}
