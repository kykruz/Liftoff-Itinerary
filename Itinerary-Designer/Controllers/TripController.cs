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
        public IActionResult Create()
        {
            List<LocationData> locationDatas = context.LocationDatas.ToList();
            return View(locationDatas);
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

        
        public IActionResult Success()
        {
            return View();
        }

        
        [HttpPost]
        public IActionResult Delete()
        {
            // ViewBag.events = EventData.GetAll();

            // gotta come back later and make sure this really directs somewhere
            return Redirect("/");
        }
    }
}
