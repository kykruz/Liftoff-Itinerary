using System;
using Microsoft.EntityFrameworkCore;
using Trips.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Itinerary.Models;
using Reviews.Models;


namespace Trips.Data
{
    public class TripDbContext : IdentityDbContext <IdentityUser, IdentityRole, string>
    {
        public DbSet<Trip> Itineraries {get; set;}
        public DbSet<LocationData> LocationDatas {get; set;}
        public DbSet<Review> Reviews { get; set; }
          public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
        {
        }
    }
}