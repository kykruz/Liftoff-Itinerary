namespace Ratings.Models;

public class Rating 
{
    public int Id { get; set; }
    public int ItemId { get; set; }
    public int Stars { get; set; } 

    public Rating()
    {
        
    }
}