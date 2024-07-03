
namespace Reviews.Models;

public class Review
{
    public int Id { get; set; }
    private int nextId { get; set; }
    public string Title { get; set; }
    public string Content { get; set; }
    public DateTime PostedDate { get; set; }
    public int Rating { get; set; }
    // public bool IsAproved { get; set; }
    // public bool IsDeleted { get; set; }

    public Review()
    {
        PostedDate = DateTime.UtcNow;
    }
}
