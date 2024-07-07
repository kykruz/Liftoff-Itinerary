using System.Collections.Generic;
using Reviews.ViewModels;
using Trips.Models;

namespace Reviews.ViewModels
{
    public class ReviewViewModel
    {
        public string? Author { get; set; }
        public List<Review>? Reviews { get; set; }
        public string? Title { get; set; }
    }
    
}
