using System;
using LocationDatay.Models;

namespace Itineraries.Models
{
    public class Itinerary
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        // public LocationData LocationDatas {get; set;}



      
        public Itinerary() {}
        public Itinerary (string name)
        {
            Name = name;
            // LocationDatas = locationData;
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
