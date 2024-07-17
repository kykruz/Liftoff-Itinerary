using System.Collections.Generic;
using Trips.ViewModels;
using Trips.Models;
using System.ComponentModel.DataAnnotations;

namespace Trips.ViewModels
{
    public class ReviewViewModel
    {
        
        public string? Username { get; set; }

        [Required(ErrorMessage = "Please enter the title of your review.")]
        public string? Title { get; set; }

        [Required(ErrorMessage = "Please enter the review content.")]
        public string? ReviewPost { get; set; }
        public IFormFile ImageFile { get; set; }
        
        public DateTime PostedDate { get; set; }
        public string? ImagePath { get; set; }
        
        public ReviewViewModel() {}
    }
    
}
