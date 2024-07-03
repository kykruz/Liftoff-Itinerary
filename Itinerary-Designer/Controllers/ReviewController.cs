using Microsoft.AspNetCore.Mvc;
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
        var posts = context.Reviews.ToList();
        return View(posts);
    }
    public IActionResult Create()
    {
        return View();
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

