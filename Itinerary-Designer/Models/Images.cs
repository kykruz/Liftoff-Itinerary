using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Trips.Models;

public class Image
{
    public int Id { get; set; }
    public string? Title { get; set; }
    
    public string? Author { get; set; }
    
    public string Content { get; set; }
    public Image images { get; set; }
    public IFormFile ImageFile { get; set; }
    
    public DateTime PostedDate { get; set; }
    
    public Image()
    {
        PostedDate = DateTime.UtcNow;
    }
    public Image(string title, string author, string content)
    {
        Title = title;
        Author = author;
        Content = content;
        
    }
    
}
