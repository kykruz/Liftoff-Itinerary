using System;
using Trips.Models;

namespace Trips.Models
{
    public class Itinerary
    {
        public int? Id { get; set; }
        public string? Name { get; set; }
        public List<int>? LocationIds {get; set;}
        public DateTime? Date {get; set;}

      
        public Itinerary() {}
        public Itinerary (string name, List<int> locationIds, DateTime date)
        {
            Name = name;
            LocationIds = locationIds;
            Date = date;
            
        }

        public override string ToString()
        {
            return Name;
        }

        public override bool Equals(object? obj)
        {
            return obj is LocationData @location && Id == @location.Id;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }

   
}