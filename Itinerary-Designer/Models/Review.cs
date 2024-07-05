
namespace Reviews.Models;

public class Review
{
    public int Id { get; set; }
    private int nextId { get; set; } = 1;
    public string Title { get; set; }
    public string Author { get; set; }
    public string Content { get; set; }
    public DateTime PostedDate { get; set; }
    public object Comments { get; internal set; }

    // public int Rating { get; set; }
    // public bool IsAproved { get; set; }
    // public bool IsDeleted { get; set; }

    public Review()
    {
        Id = nextId;
        nextId++;
        PostedDate = DateTime.UtcNow;
    }
    public Review(string title, string author, string content)
    {
        Title = title;
        Author = author;
        Content = content;
    }
    public class Comment
    {
        public int Id { get; set;}
        public required string Content { get; set;}
        public DateTime PostedDate { get; set;}
        public int ReviewId { get; set;}
        public required Review Review { get; set;}
    }
    
}
