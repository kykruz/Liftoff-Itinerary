using System;
using System.IO;
using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Trips.Data;
using Trips.Models;
using Trips.ViewModels;

namespace Trips.Controllers
{
    public class ReviewController : Controller
    {
        private readonly TripDbContext _context;

        public ReviewController(TripDbContext context)
        {
            _context = context;
        }

        public IActionResult Index()
        {
            var reviews = _context.Reviews.ToList();
            var reviewViewModels = reviews
                .Select(r => new ReviewViewModel
                {
                    Author = r.Author,
                    Title = r.Title,
                    Content = r.Content,
                    PostedDate = r.PostedDate,
                    ImagePath = r.ImagePath // Ensure you map ImagePath if needed
                })
                .ToList();

            return View(reviewViewModels);
        }

        [HttpGet]
        [Route("Review/Create")]
        public IActionResult Create()
        {
            var reviewViewModel = new ReviewViewModel();
            return View(reviewViewModel);
        }

        [HttpPost]
        [Route("Review/Create")]
        public IActionResult Create(ReviewViewModel reviewViewModel)
        {
            //if (ModelState.IsValid)
            {
                var review = new Review
                {
                    Author = reviewViewModel.Author,
                    Title = reviewViewModel.Title,
                    Content = reviewViewModel.Content,
                    PostedDate = DateTime.Now
                };

                // Save the review entity to the database
                _context.Reviews.Add(review);
                _context.SaveChanges();

                // Handle file upload if there is a file
                if (reviewViewModel.ImageFile != null && reviewViewModel.ImageFile.Length > 0)
                {
                    var fileName = Path.GetFileName(reviewViewModel.ImageFile.FileName);
                    var filePath = Path.Combine(
                        Directory.GetCurrentDirectory(),
                        "wwwroot/images",
                        fileName
                    );

                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        reviewViewModel.ImageFile.CopyTo(stream);
                    }

                    // Update the review entity with the image path

                    review.ImagePath = "/images/" + fileName;
                    _context.SaveChanges(); 
                    
                    // Save changes to update the review entity with the image path
                }

                return RedirectToAction("Details", new { id = review.Id });
            }

            // If ModelState is not valid, return the view with the same ViewModel
            return View("Create", reviewViewModel);
        }

        public IActionResult Details(int id)
        {
            var review = _context.Reviews.FirstOrDefault(r => r.Id == id);

            if (review == null)
            {
                return NotFound(); // Incase if review with given id is not found
            }

            var reviewViewModel = new ReviewViewModel
            {
                Author = review.Author,
                Title = review.Title,
                Content = review.Content,
                PostedDate = review.PostedDate,
                ImagePath = review.ImagePath // map imagepath if needed
            };

            return View(reviewViewModel);
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
}
