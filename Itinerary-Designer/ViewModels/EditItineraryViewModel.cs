using System;
using System.Collections.Generic;
using Trips.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc;

public class EditItineraryViewModel
{
    public int ItineraryId { get; set; }

    public string Name { get; set; }

    public DateTime Date { get; set; }

    public List<int> SelectedLocationIds { get; set; }
    public List<string> SelectedCategories { get; set; }

    public List<string> AvailableCategories { get; set; }
    public List<LocationData> AvailableLocations { get; set; }

    public EditItineraryViewModel()
    {
        AvailableLocations = new List<LocationData>();
        SelectedLocationIds = new List<int>();
        AvailableCategories = new List<string>();
        SelectedCategories = new List<string>();
    }
}
