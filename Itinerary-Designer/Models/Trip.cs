using System;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Trips.Models
{
    public class Trip
    {
        public string TripName { get; set; }

        public int PeopleCount { get; set; }

        public double CalculatedCost { get; set; }
        public List<SelectListItem>? Itineraries { get; set; } = new List<SelectListItem>();

      

        public int Id { get; set; }
        

        public Trip() {}
        

        public Trip(string tripname)
        {
            TripName = tripname;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}


