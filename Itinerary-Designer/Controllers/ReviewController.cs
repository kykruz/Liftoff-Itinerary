using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Trips.Models;
using Trips.Data;
using Trips.ViewModels;

namespace Trips.Controllers;

public class ReviewController : Controller
{
    private readonly TripDbContext context;

    public ReviewController(TripDbContext _context)
    {
        context = _context;
    }
    public IActionResult Index()
    {
        var post = context.Reviews.ToList();
        return View(post);
    }
    public IActionResult Create()
    {
        ReviewViewModel reviewViewModel = new ReviewViewModel();
        return View(reviewViewModel);
    }
    [HttpPost]
    public async Task<IActionResult> Create(ReviewViewModel viewModel)
    {
        if(ModelState.IsValid)
        {
            var review = new Review
            {
                Author = viewModel.Author,
                PostedDate = DateTime.Now
            };
            
            context.Reviews.Add(review);
            await context.SaveChangesAsync();
            return RedirectToAction("Index");
        }
        return View(viewModel);
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

