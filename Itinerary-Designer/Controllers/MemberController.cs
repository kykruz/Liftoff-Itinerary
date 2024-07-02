using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualStudio.Web.CodeGenerators.Mvc.Templates.General;

public class MemberController : Controller
{
    private readonly ApplicationDbContext _context; // Replace with your DbContext
    private readonly UserManager<ApplicationUser> _userManager;

    public MemberController(ApplicationDbContext context, UserManager<ApplicationUser> userManager)
    {
        _context = context;
        _userManager = userManager;
    }

    // Action to display comments
    public IActionResult Comments()
    {
        var comments = _context.Comments.Include(c => c.User).ToList(); // Load comments from database
        return View(comments);
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

    // Action to display pictures (similar to the Reviews)
    public IActionResult Pictures()
    {
        // Load pictures from database
        var pictures = _context.Pictures.Include(p => p.User).ToList();
        return View(pictures);
    }

    // Action to upload a picture
    [HttpPost]
    public async Task<IActionResult> UploadPicture(IFormFile file)
    {
        var user = await _userManager.GetUserAsync(User);

        if (user == null)
        {
            return RedirectToAction("Login", "Account");
        }

        // Save picture to the database or file system


        return RedirectToAction(nameof(Pictures));
    }

  
}
