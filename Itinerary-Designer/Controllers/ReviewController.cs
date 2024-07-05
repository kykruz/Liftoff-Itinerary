using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reviews.Models;
using Trips.Data;

namespace Reviews.Controllers;

public class ReviewController : Controller
{
    private readonly TripDbContext context;

    public ReviewController(TripDbContext _context)
    {
        context = _context;
    }
    public IActionResult Index()
    {
        var reviews = context.Reviews.ToList();
        return View(reviews);
    }
    public IActionResult Create()
    {
        var reviews = context.Reviews.ToList();
        return View(reviews);
    }
    [HttpPost]
    public async Task<IActionResult> Create(Review reviews)
    {
        if(ModelState.IsValid)
        {
            try
            {
            reviews.PostedDate = DateTime.Now;

            context.Reviews.Add(reviews);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            }
            catch (DbUpdateException ex)
            {
                ModelState.AddModelError("", "Unable to save changes. Try Again, and if the problem persists, see your system administrator.");
            }
        }
        return View(reviews);
    }
    public IActionResult Edit()
    {
        return View();
    }
    public IActionResult Delete()
    {
        return View();
    }
}

