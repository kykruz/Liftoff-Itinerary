using System.Diagnostics;
using CreateItinerary.ViewModel;
using Itineraries.Models;
using LocationDatay.Models;
using Microsoft.AspNetCore.Mvc;
using Trips.Data;
using Trips.Models;

namespace Itineraryy.Controllers
{
    public class ItineraryController : Controller
    {
        private TripDbContext context;

        public ItineraryController(TripDbContext dbContext)
        {
            context = dbContext;
        }

        public IActionResult Index()
        {
            List<Itinerary> Itinerary = context.Itineraries.ToList();
            return View(Itinerary);
        }

        
        [HttpGet]
        
        public IActionResult Create()
        {
          
            CreateItineraryViewModel createItineraryViewModel = new CreateItineraryViewModel();
            return View(createItineraryViewModel);
        }

        [HttpPost]
        
        public IActionResult Create(CreateItineraryViewModel createItineraryViewModel)
        {
            if(ModelState.IsValid)
            {
          
                Itinerary itinerary = new Itinerary
                {
                    Name = createItineraryViewModel.Name,
                    
                };
                context.Itineraries.Add(itinerary);
                context.SaveChanges();

            return Redirect("/Success");
            }
           
            return View("Create", createItineraryViewModel);
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
