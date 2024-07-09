using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
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
        var review = context.Reviews.ToList();
        var reviewViewModel = review.Select(r => new ReviewViewModel
        {
            Author = r.Author,

        }).ToList();
        return View(reviewViewModel);
    }
    [HttpGet]
    [Route("Review/Create")]
    public IActionResult Create()
    {
        ReviewViewModel reviewViewModel = new ReviewViewModel();
        return View(reviewViewModel);
    }
    [HttpPost]
    [Route("Review/Create")]
    public IActionResult Create(ReviewViewModel reviewViewModel)
    {
        if(ModelState.IsValid)
        {
            Review review = new Review
            {
                Author = reviewViewModel.Author,
                Content = reviewViewModel.Content,
                PostedDate = DateTime.Now,
                Title = reviewViewModel.Title
            };
            
            context.Reviews.Add(review);
            context.SaveChanges();

            return Redirect("Create");
        }
        return View("Create", reviewViewModel);
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

