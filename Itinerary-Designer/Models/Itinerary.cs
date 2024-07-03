using System;

namespace Itinerary.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        private static int nextId = 1;
        public string Name { get; set; }
        public List<LocationData> LocationDatas {get; set;}



        public Itinerary ()
        {
            Id = nextId;
            nextId++;
        }

        public Itinerary (string name, List<LocationData> locationData)
        {
            Name = name;
            LocationDatas = locationData;
            Id = nextId;
            nextId++;
        }

        public override string ToString()
        {
            return Name;
        }

        // public override bool Equals(object? obj)
        // {
        //     return obj is Event @event && Id == @event.Id;
        // }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }

    public class Event
    {
    }
}
