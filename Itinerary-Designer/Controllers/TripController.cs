using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trips.Models;
using Trips.Data;
using Itinerary.Models;

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
    public IActionResult Create()
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