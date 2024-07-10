using System;
using System.ComponentModel.DataAnnotations;
using System.Drawing;

namespace Trips.Models;

public class Review
{
    public int Id { get; set; }
    public string? Title { get; set; }
    
    public string? Author { get; set; }
    
    public string Content { get; set; }
    public byte[]? ImageFile { get; set; }
    
    public DateTime PostedDate { get; set; }
    public string ImagePath { get; set; }
    
    public Review()
    {
        PostedDate = DateTime.UtcNow;
    }
    public Review(string title, string author, string content)
    {
        Title = title;
        Author = author;
        Content = content;
    }
    
}
