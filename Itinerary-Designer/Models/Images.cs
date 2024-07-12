using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Trips.Models;

public class Image
{
    public int Id { get; set; }
    public string? Title { get; set; }
    
    public string? Username { get; set; }
    
    public string ReviewPost { get; set; }
    public Image images { get; set; }
    public IFormFile ImageFile { get; set; }
    
    public DateTime PostedDate { get; set; }
    
    public Image()
    {
        PostedDate = DateTime.UtcNow;
    }
    public Image(string title, string username, string reviewPost)
    {
        Title = title;
        Username = username;
        ReviewPost = reviewPost;
        
    }
    
}
