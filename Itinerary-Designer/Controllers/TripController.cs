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
            List<Itinerary> Itinerary = context.Itineraries.ToList();
            return View(Itinerary);
        }

        
        [HttpGet]
        [Route("Itinerary/Create")]
        public IActionResult Create()
        {
          
            CreateItineraryViewModel createItineraryViewModel = new CreateItineraryViewModel();
            return View(createItineraryViewModel);
        }

        [HttpPost]
        [Route("Itinerary/Create")]
        public IActionResult Create(CreateItineraryViewModel createItineraryViewModel)
        {
            if(ModelState.IsValid)
            {
            //      var selectedLocations = _context.LocationDatas
            // .Where(loc => viewModel.SelectedLocationIds.Contains(loc.Id))
                Itinerary itinerary = new Itinerary
                {
                    Name = createItineraryViewModel.Name,
                    
                };
                context.Itineraries.Add(itinerary);
                context.SaveChanges();

            return Redirect("/Success");
            }
           
            return View("Itinerary/Create", createItineraryViewModel);
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
