using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.Data;
using Trips.Models;

namespace Trips.Controllers
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
            var viewModel = new CreateItineraryViewModel();
            viewModel.AvailableLocations = context.LocationDatas.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(CreateItineraryViewModel createItineraryViewModel)
        {
            if (ModelState.IsValid)
            {
                // Create new Itinerary instance
                var itinerary = new Itinerary
                {
                    Name = createItineraryViewModel.Name,
                    LocationDatas = createItineraryViewModel
                        .AvailableLocations.Where(l => l.IsSelected)
                        .Select(l => new LocationData
                        {
                           Id = l.Id,
                            Name = l.Name,
                            Address = l.Address,
                            Category = l.Category,
                            PricePerPerson = l.PricePerPerson,
                            Description = l.Description,
                            Phone = l.Phone,
                            
                        })
                        .ToList()
                };

              
                context.Itineraries.Add(itinerary);
                context.SaveChanges();

                return RedirectToAction("Success");
            }

       
            return View(createItineraryViewModel);
        }

        public IActionResult Success()
        {
       
            List<Itinerary> itineraries = context
                .Itineraries.Include(i => i.LocationDatas)
                .ToList();

            return View(itineraries);
        }

        public IActionResult ViewLocations(int itineraryId)
        {
            Itinerary itinerary = context
                .Itineraries.Include(i => i.LocationDatas)
                .FirstOrDefault(i => i.Id == itineraryId);

            if (itinerary == null)
            {
                return NotFound();
            }

            return View(itinerary);
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