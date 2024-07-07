using System;
using System.ComponentModel.DataAnnotations;

namespace Trips.Models;

public class Review
{
    public int Id { get; set; }
    public string? Title { get; set; }
    [Required]
    public string? Author { get; set; }
    [Required]
    public string Content { get; set; }
    [Display(Name = "Posted Date")]
    public DateTime PostedDate { get; set; }
    
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
