using Microsoft.AspNetCore.Mvc;
using Exchange.Services;
using Trips.Models; 
using System;
using System.Threading.Tasks;

public class PaymentController : Controller
{
    private readonly ExchangeRatesApiService _exchangeService;

    public PaymentController(ExchangeRatesApiService exchangeService)
    {
        _exchangeService = exchangeService;
    }

    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public async Task<IActionResult> ProcessPayment(PaymentModel payment)
    {
        if (!ModelState.IsValid)
        {
            // If model state is not valid, return to the form with errors
            return View("Index", payment); // Pass payment model back to view with errors
        }

        try
        {
            // Call your external API here to process the payment asynchronously
            var result = await _exchangeService.ProcessPaymentAsync(payment);

            if (result.Success)
            {
                // If payment successful, redirect to payment result page
                return RedirectToAction("PaymentResult", new { success = true });
            }
            else
            {
                // If payment failed, handle accordingly (possibly show error message)
                ModelState.AddModelError(string.Empty, "Payment processing failed. Please try again.");
                return View("Index", payment); // Return to payment form with error message
            }
        }
        catch (Exception ex)
        {
            // Log the exception and handle it gracefully
            ModelState.AddModelError(string.Empty, "Payment processing encountered an error. Please try again later.");
            return View("Index", payment); // Return to payment form with error message
        }
    }
}
