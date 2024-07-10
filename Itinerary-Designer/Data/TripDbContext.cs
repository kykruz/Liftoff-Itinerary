
using System;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Hosting;

using Trips.Models;

namespace Trips.Data
{
    public class TripDbContext : IdentityDbContext<User, IdentityRole, string>
    {
        public DbSet<Itinerary> Itineraries { get; set; }
        public DbSet<LocationData> LocationDatas { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<Chat> Chats { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<ItineraryLocationData> ItineraryLocationDatas { get; set; }

        public TripDbContext(DbContextOptions<TripDbContext> options)
            : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Composite primary key for ItineraryLocationData
            modelBuilder.Entity<ItineraryLocationData>()
                .HasKey(il => new { il.ItineraryId, il.LocationDataId });

            // Defining relationship between ItineraryLocationData and Itinerary
            modelBuilder.Entity<ItineraryLocationData>()
                .HasOne(il => il.Itinerary)
                .WithMany(i => i.ItineraryLocationDatas)
                .HasForeignKey(il => il.ItineraryId);

            // Defining relationship between ItineraryLocationData and LocationData
            modelBuilder.Entity<ItineraryLocationData>()
                .HasOne(il => il.LocationData)
                .WithMany(ld => ld.ItineraryLocationDatas)
                .HasForeignKey(il => il.LocationDataId);
        }
    }
}

