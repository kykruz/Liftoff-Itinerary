using System;
using Microsoft.EntityFrameworkCore;
using Trips.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Itineraries.Models;
using Reviews.Models;
using Ratings.Models;
using LocationDatay.Models;


namespace Trips.Data
{
    public class TripDbContext : IdentityDbContext <IdentityUser, IdentityRole, string>
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