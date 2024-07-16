using System;
using System.Threading.Tasks;
using Exchange.Services;
using Microsoft.AspNetCore.Mvc;
using Trips.Models;

namespace Trips.Controllers
{
    public class PaymentController : Controller
    {
        private readonly ExchangeRatesApiService _exchangeService;

        public PaymentController(ExchangeRatesApiService exchangeService)
        {
            _exchangeService = exchangeService;
        }

        public IActionResult Index()
        {
            return View(new PaymentViewModel());
        }

        [HttpPost]
        public async Task<IActionResult> ProcessPayment(PaymentViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                // If model state is not valid, return to the form with errors

                return View("Index", viewModel); 
                
                // Pass payment model back to view with errors
            }

            try
            {
                // Call your external API here to process the payment asynchronously

                var result = await _exchangeService.ProcessPaymentAsync(viewModel.PaymentModel);

                if (result.Success)
                {
                    // If payment successful, redirect to payment result page

                    return RedirectToAction("PaymentResult", new { success = true });
                }
                else
                {
                    // If payment failed, handle accordingly (possibly show error message)

                    ModelState.AddModelError(
                        string.Empty,
                        "Payment processing failed. Please try again.");
                    return View("Index", viewModel); 
                    
                    // Return to payment form with error message
                }
            }
            catch (Exception)
            {
                // Log the exception and handle it gracefully

                ModelState.AddModelError(
                    string.Empty,
                    "Payment processing encountered an error. Please try again later."
                );
                return View("Index", viewModel); 
                
                // Return to payment form with error message

            }
        }
        [HttpPost]
        public async Task<IActionResult> ConvertCurrency(PaymentViewModel viewModel)
        {
            try
            {
                var result = await _exchangeService.ConvertAsync(viewModel.ConvertRequest);
                viewModel.ConvertResponse = result;
                return View("Index", viewModel);
            }
            catch (Exception)
            {
                ModelState.AddModelError(string.Empty, "Currency conversion encountered an error. Please try again later.");
                return View("Index", viewModel);
            }
        }
    }
}
