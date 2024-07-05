using System.Diagnostics;
using CreateItinerary.ViewModel;
using Itineraries.Models;
using LocationDatay.Models;
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
        public IActionResult Create(CreateItineraryViewModel createItineraryViewModel)
        {
            if(ModelState.IsValid)
            {
                LocationData locationData = context.LocationDatas.Find(createItineraryViewModel.Id);
                Itinerary itinerary = new Itinerary
                {
                    Name = createItineraryViewModel.Name,
                    LocationDatas = locationData
                };

                context.Itineraries.Add(itinerary);
                context.SaveChanges();

            

            return Redirect("Success");
            }
            // foreach (int locationId in locationIds)
            // {
            //     LocationData location = context.LocationDatas.Find(locationId);
            //     context.LocationDatas.Add(location);
            // }

            context.SaveChanges();
            return View(createItineraryViewModel);
        }

        
        public IActionResult Success()
        {
            
            List<LocationData> locationDatas = context.LocationDatas.ToList();
            return View(locationDatas);
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
