using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Trips.Models;
using Trips.Data;

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
        return View();
    }
    [HttpPost]
    public async Task<IActionResult> Create(Review post)
    {
        if(ModelState.IsValid)
        {
            post.PostedDate = DateTime.Now;
            context.Reviews.Add(post);
            await context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }
        return View(post);
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

