using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.Data;
using Trips.Models;

namespace Trips.Controllers
{
    [Authorize]
    public class ItineraryController : Controller
    {
        private readonly TripDbContext context;

        public ItineraryController(TripDbContext dbContext)
        {
            context = dbContext;
        }

        private string GetCurrentUserId()
        {
            return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
        }

         public IActionResult Index()
        {
            var itineraries = new List<ItineraryViewModel>
            {
                new ItineraryViewModel { Title = "Trip to Venice", Description = "Explore the beautiful canals of Venice.", ImageUrl = "/images/venice.jpg" },
                new ItineraryViewModel { Title = "Trip to Paris", Description = "Visit the iconic Eiffel Tower.", ImageUrl = "/images/paris.jpg" },
                new ItineraryViewModel { Title = "Trip to New York", Description = "Experience the bustling city life.", ImageUrl = "/images/newyork.jpg" }
            };

            return View(itineraries);
        }

        [HttpGet]
        public IActionResult PreMade()
        {
            List<Itinerary> itineraries = PreMadeItineraries.GetPreMadeItineraries();
            return View(itineraries);
        }

        [HttpPost]
        public async Task<IActionResult> PreMade(int[] selectedItineraries)
        {
            string userId = GetCurrentUserId();

            foreach (int itineraryId in selectedItineraries)
            {
                var preMadeItinerary = PreMadeItineraries
                    .GetPreMadeItineraries()
                    .FirstOrDefault(i => i.Id == itineraryId);
                if (preMadeItinerary != null)
                {
                    List<LocationData> selectedLocationDatas = preMadeItinerary.LocationDatas;

                    Itinerary itinerary = new Itinerary
                    {
                        Name = preMadeItinerary.Name,
                        UserId = userId,
                        ItineraryLocationDatas = selectedLocationDatas
                            .Select(ld => new ItineraryLocationData { LocationData = ld })
                            .ToList(),
                        Date = DateTime.UtcNow
                    };

                    context.Itineraries.Add(itinerary);
                }
            }

            await context.SaveChangesAsync();

            return RedirectToAction("Success");
        }

        [HttpGet]
        public IActionResult Create()
        {
            CreateItineraryViewModel viewModel = new CreateItineraryViewModel();

            // Fetch distinct categories from LocationDatas
            viewModel.AvailableCategories = context.LocationDatas
                .Select(ld => ld.Category)
                .Distinct()
                .ToList();

            // Initially load all locations
            viewModel.AvailableLocations = context.LocationDatas.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItineraryViewModel createItineraryViewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = GetCurrentUserId();

                // Filter locations by selected categories
                List<LocationData> selectedLocationDatas = await context
                    .LocationDatas
                    .Where(ld =>
                        createItineraryViewModel.SelectedLocationIds.Contains(ld.Id) &&
                        createItineraryViewModel.SelectedCategories.Contains(ld.Category)
                    )
                    .ToListAsync();

                Itinerary itinerary = new Itinerary
                {
                    Name = createItineraryViewModel.Name,
                    UserId = userId,
                    ItineraryLocationDatas = selectedLocationDatas
                        .Select(ld => new ItineraryLocationData { LocationData = ld })
                        .ToList(),
                    Date = createItineraryViewModel.Date.Date
                };

                context.Itineraries.Add(itinerary);
                await context.SaveChangesAsync();

                return RedirectToAction("Success");
            }

            // Reload available categories and locations
            createItineraryViewModel.AvailableCategories = context.LocationDatas
                .Select(ld => ld.Category)
                .Distinct()
                .ToList();
            createItineraryViewModel.AvailableLocations = context.LocationDatas.ToList();

            return View(createItineraryViewModel);
        }

        public async Task<IActionResult> Success()
        {
            string userId = GetCurrentUserId();

            List<Itinerary> itineraries = await context
                .Itineraries.Where(i => i.UserId == userId)
                .Include(i => i.ItineraryLocationDatas)
                .ThenInclude(il => il.LocationData)
                .ToListAsync();

            return View(itineraries);
        }

        public async Task<IActionResult> ViewLocations(int itineraryId)
        {
            string userId = GetCurrentUserId();

            Itinerary itinerary = await context
                .Itineraries.Where(i => i.UserId == userId && i.Id == itineraryId)
                .Include(i => i.ItineraryLocationDatas)
                .ThenInclude(il => il.LocationData)
                .FirstOrDefaultAsync();

            if (itinerary == null)
            {
                return NotFound();
            }

            return View(itinerary);
        }

        [HttpGet]
        public IActionResult Delete()
        {
            string userId = GetCurrentUserId();

            List<Itinerary> itineraries = context
                .Itineraries.Where(i => i.UserId == userId)
                .ToList();

            return View("Delete", itineraries);
        }

        [HttpPost]
        public async Task<IActionResult> Delete(int[] ItineraryIds)
        {
            foreach (int id in ItineraryIds)
            {
                Itinerary? theItinerary = await context.Itineraries.FindAsync(id);
                if (theItinerary != null)
                {
                    context.Itineraries.Remove(theItinerary); // remove one from list
                }
            }
            await context.SaveChangesAsync(); // after all have been removed from the list

            string userId = GetCurrentUserId();
            List<Itinerary> itineraries = await context
                .Itineraries.Where(i => i.UserId == userId)
                .ToListAsync();

            return View("Delete", itineraries);
        }
    }
}
