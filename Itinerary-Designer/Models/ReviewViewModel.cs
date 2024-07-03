using System;
using Itinerary;

namespace ReviewViewModel.Models
{
    public class Comment
    {
        public int CommentId { get; set; }
        public string Content { get; set; }
        public string UserId { get; set; }
        public DateTime CreatedAt { get; set; }
        
        //public virtual TripUser User { get; set; }
    }
}
