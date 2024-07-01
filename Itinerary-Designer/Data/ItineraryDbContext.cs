using System;
using Microsoft.EntityFrameworkCore;
using Itinerary.Models;
using Microsoft.Extensions.Hosting;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Itinerary_Designer.Data
{
    public class ItineraryDbContext : IdentityDbContext <IdentityUser, IdentityRole, string>
    {
          public ItineraryDbContext(DbContextOptions<ItineraryDbContext> options) : base(options)
        {
        }
    }
}