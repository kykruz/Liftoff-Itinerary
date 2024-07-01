using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Itinerary_Designer.Models;
using Itinerary_Designer.Data;

namespace Itinerary_Designer.Controllers;

public class ItineraryController : Controller
{
    private ItineraryDbContext context;

    public ItineraryController()
    {
    
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }


    // [HttpPost]
    // public IActionResult Create(CreateItineraryViewModel createItineraryViewModel)
    // {
    //     return View();
    // }


}
