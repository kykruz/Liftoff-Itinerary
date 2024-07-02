using Itinerary.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Itinerary.Controllers;

public class CreateItineraryController : Controller
{
     public IActionResult Index()
    {
         var CreateItineraryModel = new CreateItineraryViewModel()
{
  IsChecked = false
};
return View("CreateItineraryViewModel");
    }
}