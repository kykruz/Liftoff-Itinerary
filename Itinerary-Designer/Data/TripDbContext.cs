using System;
using Itinerary.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;
using Reviews.Models;
using Trips.Models;
using static Reviews.Models.Review;

namespace Trips.Data
{
    public class TripDbContext : IdentityDbContext<IdentityUser, IdentityRole, string>
    {
        public DbSet<Trip> Itineraries { get; set; }
        public DbSet<LocationData> LocationDatas { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Comment> Comments { get; set; }

        public TripDbContext(DbContextOptions<TripDbContext> options)
            : base(options) { }
        //     protected override void OnModelCreating(ModelBuilder modelBuilder)
        //     {
        //         base.OnModelCreating(modelBuilder);

        //         modelBuilder.Entity<Comment>()
        //             .HasOne(c => c.Review)
        //             .WithMany(r => r.Comments)
        //             .HasForeignKey(c => c.ReviewId)
        //             .OnDelete(DeleteBehavior.Cascade);
        // }
    }
}
