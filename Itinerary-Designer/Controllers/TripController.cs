using System.Diagnostics;
using Itinerary.Models;
using Microsoft.AspNetCore.Mvc;
using Trips.Data;
using Trips.Models;

namespace Trips.Controllers
{
    public class TripController : Controller
    {
        private TripDbContext context;

        public TripController(TripDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Trip> Itinerary = context.Itineraries.ToList();
            return View(Itinerary);
        }

        //
        [HttpGet]
        [Route("Itinerary/Create")]
        public IActionResult Create(string tripName, List<int> selectedLocations)
      {
            // Handle the form submission
            // Save tripName and selectedLocations to the database if needed

            // Pass the selected locations to the Success view
            return RedirectToAction("Success", new { tripName = tripName, selectedLocations = selectedLocations });
        }

        [HttpPost]
        public IActionResult Create(List<int> selectedLocations)
        {
            if (selectedLocations != null && selectedLocations.Any())
            {
                // Process the selected locations
                // For example, save them to the database or perform other actions
            }
            return RedirectToAction("Success");
        }

        
        public IActionResult Success(string tripName, List<int> selectedLocations)
        {
            // Retrieve the location details based on the selected IDs if needed
            var selectedLocationDetails = new List<LocationData>();
            foreach (var locationId in selectedLocations)
            {
                // Replace this with actual data retrieval logic
                var location = new LocationData
                {
                    Id = locationId,
                    Name = "Location Name " + locationId,
                    Address = "Location Address " + locationId,
                    Category = "Category " + locationId,
                    PricePerPerson = 100 + locationId,
                    Description = "Description " + locationId,
                    Phone = "Phone " + locationId
                };
                selectedLocationDetails.Add(location);
            }

            ViewBag.TripName = tripName;
            ViewBag.SelectedLocations = selectedLocationDetails;

            return View("Success");
        }
    }
}

