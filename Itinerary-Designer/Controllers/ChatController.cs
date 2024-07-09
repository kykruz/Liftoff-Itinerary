using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
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
public async Task<IActionResult> Messaging()
  {
    List<Chat?> chatLog = await context.Chats.ToListAsync();
    ChatViewModel chatViewModel = new ChatViewModel();
    return View(chatViewModel);
  }
        
[HttpPost]
  public async Task<IActionResult> Messaging(ChatViewModel chatViewModel)
  {
    if(ModelState.IsValid)
    {
    Chat chat = new Chat
    {
        Message = chatViewModel.Message,
        Date = DateTime.Now
    };
    context.Chats.Add(chat);
    await context.SaveChangesAsync();

    return RedirectToAction("Messaging");
    }

    return View(chatViewModel);
  }
        
}