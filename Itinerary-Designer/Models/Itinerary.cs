using System;
using Trips.Models;

namespace Trips.Models
{
    public class Itinerary
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public DateTime Date {get; set;}
        
        public List<LocationData> LocationDatas { get; set; } = new List<LocationData>();
        public List<ItineraryLocationData> ItineraryLocationDatas { get; set; } = new List<ItineraryLocationData>();

        public string UserId { get; set; }

        public Itinerary() {}
        public Itinerary (string name, List<LocationData> locationData)
        {
            Name = name;
            LocationDatas = locationData;
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
