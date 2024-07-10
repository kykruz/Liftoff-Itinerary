using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trips.Models;
using Trips.Data;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
using Trips.ViewModels;

namespace Trips.Controllers
{
    [Authorize(Roles = "Admin")]
    public class UserController : Controller
    {
        private readonly TripDbContext _context;

        public UserController(TripDbContext context)
        {
            _context = context;
        }

        public async Task<IActionResult> Index()
        {
            List<User> users = await _context.Users.ToListAsync();
            return View(users);
        }
    }
}
