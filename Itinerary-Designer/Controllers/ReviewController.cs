using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
using Trips.Models;
using Trips.Data;
using Trips.ViewModels;
using Microsoft.AspNetCore.Routing.Constraints;

namespace Trips.Controllers;

[Authorize(Roles = "Admin")]
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
                Title = reviewViewModel.Title,
                Content = reviewViewModel.Content,
                PostedDate = DateTime.Now
            };
            
            context.Reviews.Add(review);
            context.SaveChanges();

            if (reviewViewModel.ImageFile != null && reviewViewModel.ImageFile.Length > 0)
            {
                var fileName = Path.GetFileName(reviewViewModel.ImageFile.FileName);
                var filePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot/images", fileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    reviewViewModel.ImageFile.CopyTo(stream);
                }
                review.ImagePath = "/images/" + fileName;
            }

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

