using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using Trips.Data;
using Trips.Models;
using Trips.ViewModels;

namespace Trips.Controllers;

[Authorize]
public class ChatController : Controller
{
  private TripDbContext context;

private string GetCurrentUserId()
{
 return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
}
  public ChatController(TripDbContext _context)
  {
    context = _context;
  }

[HttpGet]
public async Task<IActionResult> Messaging()
  {
    List<Chat?> chatLog = await context.Chats.ToListAsync();
    ChatViewModel chatViewModel = new ChatViewModel(chatLog);
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
        UserId = userId,
        Date = DateTime.Now
    };
    context.Chats.Add(chat);
    await context.SaveChangesAsync();

    return RedirectToAction("Messaging");
    }

    return View(chatViewModel);
  }
        
}