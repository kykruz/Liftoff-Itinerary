using Trips.Models;

namespace Trips.ViewModels;

public class ChatViewModel
{
    public string? Message { get; set; }
    public DateTime Date {get; set;}
    public List<Chat?> ChatLog {get; set;}

    public ChatViewModel ()
    {
        ChatLog = new List<Chat?>();
    }
  
        
}