using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.Data;
using Trips.Models;
// y
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

        

        [HttpGet]
        public IActionResult Create()
        {
            CreateItineraryViewModel viewModel = new CreateItineraryViewModel();

            viewModel.AvailableLocations = context.LocationDatas.ToList();

            return View(viewModel);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateItineraryViewModel createItineraryViewModel)
        {
            if (ModelState.IsValid)
            {
                string userId = GetCurrentUserId();

                List<LocationData> selectedLocationDatas = await context
                    .LocationDatas.Where(ld =>
                        createItineraryViewModel.SelectedLocationIds.Contains(ld.Id)
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

        [HttpPost]
        public IActionResult Delete()
        {
            
            return Redirect("/");
        }
    }
}
