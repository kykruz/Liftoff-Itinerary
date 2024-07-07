using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Trips.Models;


namespace Trips.Data
{
    public class TripDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Itinerary> Itineraries {get; set;}
        public DbSet<LocationData> LocationDatas {get; set;}
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Rating> Ratings { get; set; }

          public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
        {
        }
    }
}