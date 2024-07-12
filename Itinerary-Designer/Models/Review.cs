using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Trips.Models;

public class Review
{
    public int Id { get; set; }
    public string? Title { get; set; }
    
    public string? Username { get; set; }
    
    public string ReviewPost { get; set; }
    
    public DateTime PostedDate { get; set; }
    public string? ImagePath { get; set; }
    
    public Review()
    {
        PostedDate = DateTime.UtcNow;
    }
    public Review(string title, string username, string reviewPost)
    {
        Title = title;
        Username = username;
        ReviewPost = reviewPost;
    }
    
}
