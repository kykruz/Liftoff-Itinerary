using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Threading.Tasks;
using Trips.Models;
using Trips.Data;
using System.Linq;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.AspNetCore.Authorization;
using Trips.ViewModels;

namespace Trips.Controllers
{
    [Authorize(Roles = "Admin")]
     public class UserController : Controller
    {
        private readonly UserManager<IdentityUser> _userManager;

        public UserController(UserManager<IdentityUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var identityUsers = _userManager.Users.ToList();
            var users = identityUsers.Select(u => new UserViewModel
            {
                Id = u.Id,
                Username = u.UserName,
                Email = u.Email
                // Map other properties as needed
            }).ToList();

            return View(users); // Ensure your view expects a list of UserViewModel
        }
    }
}