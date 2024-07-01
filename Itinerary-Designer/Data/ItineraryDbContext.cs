using System;
using Microsoft.EntityFrameworkCore;
using Itinerary.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Itinerary_Designer;

namespace Itinerary_Designer.Data
{
    public class ItineraryDbContext : IdentityDbContext <IdentityUser, IdentityRole, string>
    {
          public ItineraryDbContext(DbContextOptions<ItineraryDbContext> options) : base(options)
        {
        }
        
        public DbSet<Itinerary.Models.LocationData> LocationData { get; set; } = default!;
    }
}