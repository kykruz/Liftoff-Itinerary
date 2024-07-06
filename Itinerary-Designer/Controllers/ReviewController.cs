using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Reviews.Models;
using Trips.Data;
using static Reviews.Models.Review;

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
    
            {
            reviews.PostedDate = DateTime.Now;

            context.Reviews.Add(reviews);
            await context.SaveChangesAsync();

            return RedirectToAction(nameof(Index));

            }
        }
        return View(reviews);
    }
    // [HttpPost]
    // [ValidateAntiForgeryToken]
    // public async Task<IActionResult> AddComment(int id, Comment comment)
    // {
    //     var review = await context.Reviews.FindAsync(id);
    //     if (review == null)
    //     {
    //         return NotFound();
    //     }

    //     if (ModelState.IsValid)
    //     {
    //         comment.PostedDate = DateTime.Now;
    //         comment.ReviewId = id;
    //         context.Add(comment);
    //         await context.SaveChangesAsync();
    //         return RedirectToAction(nameof(Index));
    //     }
    //     return View(review);
    // }

    public IActionResult Edit()
    {
        return View();
    }
    public IActionResult Delete()
    {
        return View();
    }
}

