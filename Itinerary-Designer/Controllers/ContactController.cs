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
public class ContactController : Controller
{
  private TripDbContext context;

private string GetCurrentUserId()
{
 return User.FindFirst(System.Security.Claims.ClaimTypes.NameIdentifier)?.Value;
}
  public ContactController(TripDbContext _context)
  {
    context = _context;
  }

[HttpGet]
    public async Task<IActionResult> Messages()
    {
       
        ContactViewModel contactViewModel = new ContactViewModel();
        return View(contactViewModel);
    }
        
[HttpPost]
  public async Task<IActionResult> Messages(ContactViewModel contactViewModel)
  {
    if(ModelState.IsValid)
    {
       string userId = GetCurrentUserId();

    Contact contact = new Contact
    {
        Message = contactViewModel.Message,
        UserId = userId,
        Date = DateTime.Now
    };
    context.Contacts.Add(contact);
    await context.SaveChangesAsync();

    return View("Thanks");
    }

    return View(contactViewModel);
  }
[Authorize(Roles ="Admin")]
  [HttpGet]
    public IActionResult ViewContact()
    {
       List<Contact> contact = context.Contacts.ToList();
        return View(contact);
    }
        
}