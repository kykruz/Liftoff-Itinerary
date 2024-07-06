using System.Diagnostics;
using System.Linq.Expressions;
using Exchange.Services;
using Itinerary_Designer.Models;
using Microsoft.AspNetCore.Mvc;

<<<<<<< HEAD
namespace Itinerary.Controllers;

=======
namespace Home.Controllers;
>>>>>>> 242aaf4faf6094b7cd97d143bc71900f63efb9e6
// branchstuf
public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private readonly ExchangeRatesApiService _exchangeRatesApi;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
        _exchangeRatesApi = new ExchangeRatesApiService(); //initalizing
    }

    public IActionResult Index()
    {
        var userViewModel = new UserViewModel
        {
            Username = User.Identity.IsAuthenticated ? User.Identity.Name : "Guest"
        };

        return View(userViewModel);
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(
            new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier }
        );
    }

    //Action for the Currency Conversion
    [HttpPost]
    public async Task<IActionResult> CovertCurrency(
        string fromCurrency,
        string toCurrency,
        double amount
    )
    {
        try
        {
            ConvertRequest request = new ConvertRequest(fromCurrency, toCurrency, amount);
            ConvertResponse response = await _exchangeRatesApi.ConvertAsync(request);

            //Preparing data to pass to the View
            ViewData["Amount"] = amount;
            ViewData["FromCurrency"] = fromCurrency;
            ViewData["ToCurrency"] = toCurrency;
            ViewData["ConvertedAmount"] = response.Result;

            return View("Index");
        }
        catch (Exception ex)
        {
            ViewData["Error"] = ex.Message;
            return View("Index");
        }
    }
}
