using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Trips.Models;
using Trip_Designer.Data;

namespace Itinerary_Designer.Controllers;

public class ItineraryController : Controller
{
    private TripDbContext context;

    //   [HttpGet]
    //     public IActionResult Index()
    //     {
    //         List<Employer> Employer = context.Employers.ToList();
    //         return View(Employer);
    //     }
    public ItineraryController() { }

    public IActionResult Index()
    {
        List<Trip> Itinerary = context.Itineraries.ToList();
        return View(Itinerary);
    }

    [HttpGet]
    public IActionResult Create()
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
