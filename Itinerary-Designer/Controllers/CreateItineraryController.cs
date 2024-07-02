using Itinerary_Designer.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace Itinerary_Designer.Controllers;

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