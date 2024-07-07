using System.Collections.Generic;
using Trips.ViewModels;
using Trips.Models;
using System.ComponentModel.DataAnnotations;

namespace Trips.ViewModels
{
    public class ReviewViewModel
    {
        public string? Author { get; set; }
        [Required]
        public string? Title { get; set; }
        [Required]
        public string Content { get; set; }
        public DateTime PostedDate { get; set; }
        public List<Review>? Reviews { get; set; }

        public ReviewViewModel() {}
    }
    
}
