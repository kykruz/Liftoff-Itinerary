using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Linq;
using System.Threading.Tasks;
using Itinerary_Designer;
using Itinerary_Designer.Models;
using Trips.Data;
using ReviewViewModel.Models;

public class CommentController : Controller
{
    private readonly TripDbContext _context;
    private readonly UserManager<TripUser> _userManager;

    public CommentController(TripDbContext context, UserManager<TripUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Action to display comments
    public IActionResult Comments()
    {
        var comments = _context.Comments
            .Include(c => c.User)
            .Select(c => new ReviewViewModel
            {
                CommentId = c.CommentId,
                Content = c.Content,
                UserName = c.User.UserName,
                CreatedAt = c.CreatedAt
            })
            .ToList();

        var viewModel = new ReviewViewModel
        {
            Comments = comments
        };

        return View(viewModel);
    }

    // Action to add a comment
    [HttpPost]
    public async Task<IActionResult> AddComment(string content)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        var comment = new Comment
        {
            Content = content,
            UserId = user.Id,
            CreatedAt = DateTime.UtcNow
        };

        _context.Comments.Add(comment);
        await _context.SaveChangesAsync();

        return RedirectToAction(nameof(Comments));
    }
}
