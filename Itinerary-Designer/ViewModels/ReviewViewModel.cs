using System.Collections.Generic;
using Trips.ViewModels;
using Trips.Models;
using System.ComponentModel.DataAnnotations;

namespace Trips.ViewModels
{
    public class ReviewViewModel
    {
        public string? Author { get; set; }
        
        public string? Title { get; set; }
        
        public string Content { get; set; }
        public IFormFile ImageFile { get; set; }
        
        public DateTime PostedDate { get; set; }
        public string ImagePath { get; set; }
        
        public ReviewViewModel() {}
    }
    
}
