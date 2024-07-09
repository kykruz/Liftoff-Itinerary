using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Trips.Data;
using Trips.Models;
using Trips.ViewModels;

namespace Trips.Controllers;

public class ChatController : Controller
{
  private TripDbContext context;

  public ChatController(TripDbContext _context)
  {
    context = _context;
  }

[HttpGet]
public IActionResult Messaging()
  {
    ChatViewModel chatViewModel = new ChatViewModel();
    return View(chatViewModel);
  }
        
[HttpPost]
  public IActionResult Messaging(ChatViewModel chatViewModel)
  {
    if(ModelState.IsValid)
    {
    Chat chat = new Chat
    {
        Message = chatViewModel.Message,
        Date = DateTime.Now
    };
    context.Chats.Add(chat);
    context.SaveChanges();

    return View("Chat");
    }

    return View(chatViewModel);
  }
        
}