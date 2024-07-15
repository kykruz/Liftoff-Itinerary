using System.Linq;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Abstractions;
using Microsoft.EntityFrameworkCore;
using Trips.Data;
using Trips.Models;
using Trips.ViewModels;
// 
namespace Trips.Controllers;

[Authorize]
public class ChatController : Controller
{
    private readonly TripDbContext context;

    public ChatController(TripDbContext _context)
    {
        context = _context;
    }

    [HttpGet]
    public async Task<IActionResult> Messaging()
    {
        string userId = GetCurrentUserId();
        List<Chat> chatLog = await context.Chats
            .Where(c => c.UserId == userId || c.IsAdminResponse)
            .OrderBy(c => c.Date)
            .ToListAsync();

        ChatViewModel chatViewModel = new ChatViewModel(chatLog);
        return View(chatViewModel);
    }

    [HttpPost]
    public async Task<IActionResult> Messaging(ChatViewModel chatViewModel)
    {
        if (ModelState.IsValid)
        {
            string userId = GetCurrentUserId();

            Chat chat = new Chat
            {
                Message = chatViewModel.Message,
                UserId = userId,
                Date = DateTime.Now,
                IsAdminResponse = false
            };

            context.Chats.Add(chat);
            await context.SaveChangesAsync();

            return RedirectToAction("Messaging");
        }

        return View(chatViewModel);
    }

    [Authorize(Roles = "Admin")]
    [HttpGet]
    public async Task<IActionResult> AdminMessaging()
    {
        List<Chat> chatLog = await context.Chats
            .Include(c => c.ChatUser) // Include related user information if needed
            .OrderByDescending(c => c.Date)
            .ToListAsync();

        ChatViewModel chatViewModel = new ChatViewModel(chatLog);
        return View(chatViewModel);
    }

    [Authorize(Roles = "Admin")]
    [HttpPost]
    public async Task<IActionResult> AdminMessaging(ChatViewModel chatViewModel)
    {
        if (ModelState.IsValid)
        {
            string adminUserId = GetCurrentUserId();

            Chat chat = new Chat
            {
                Message = chatViewModel.Message,
                UserId = adminUserId, // Admin is responding
                Date = DateTime.Now,
                IsAdminResponse = true
            };

            context.Chats.Add(chat);
            await context.SaveChangesAsync();

            return RedirectToAction("AdminMessaging");
        }

        return View(chatViewModel);
    }

    private string GetCurrentUserId()
    {
        return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
    }
}
