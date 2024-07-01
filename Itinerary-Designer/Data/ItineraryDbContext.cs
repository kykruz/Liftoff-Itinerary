using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;

namespace Itinerary_Designer.Data
{
    public class ItineraryDbContext : IdentityDbContext <IdentityUser, IdentityRole, string>
    {
        
    }
}