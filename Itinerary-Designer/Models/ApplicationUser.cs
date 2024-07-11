using Microsoft.AspNetCore.Identity;

namespace Trips.Models
{
    public class ApplicationUser : IdentityUser
    {
        public string UserId { get; set; }
        public string Username { get; set; }

         public string Email { get; set; }
    }
}



