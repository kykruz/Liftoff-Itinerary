using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Trips.Models;
using Trips.Data;
using Microsoft.AspNetCore.Authorization;
namespace TripsController.Controllers;

[Authorize]
public class RatingController : Controller
{
    private readonly TripDbContext context;

    public RatingController(TripDbContext _context)
    {
        context = _context;
    }

    [HttpGet]
    public async Task<IActionResult> Index(int itemId)
    {
        var ratings = await context.Ratings
            .Where(r => r.ItemId == itemId)
            .ToListAsync();

        double averageRating = ratings.Any() ? ratings.Average(r => r.Stars) : 0;

        ViewBag.AverageRating = averageRating;
        ViewBag.ItemId = itemId;

        return View();
    }

    [HttpPost]
    public async Task<IActionResult> Rate(int itemId, int stars)
    {
        Rating rating = new Rating
        {
            ItemId = itemId,
            Stars = stars
        };

        context.Ratings.Add(rating);
        await context.SaveChangesAsync();

        return RedirectToAction("Index", new { itemId });
    }
}