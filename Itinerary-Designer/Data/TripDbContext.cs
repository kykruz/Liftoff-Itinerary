using System;
using Microsoft.EntityFrameworkCore;
using Trips.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Itinerary.Models;
using ReviewViewModel.Models;

namespace Trips.Data
{
    public class TripDbContext : IdentityDbContext <IdentityUser, IdentityRole, string>
    {
        public DbSet<Trip> Itineraries {get; set;}
<<<<<<< HEAD
        public DbSet<LocationData> LocationDatas {get; set;}
=======
        public DbSet<LocationData> LocationData {get; set;}
        public DbSet<Comment> Comments { get; set; }
>>>>>>> pages
          public TripDbContext(DbContextOptions<TripDbContext> options) : base(options)
        {
        }
    }
}