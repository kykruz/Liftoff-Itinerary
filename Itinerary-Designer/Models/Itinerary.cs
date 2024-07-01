using System;

namespace Itinerary.Models
{
    public class Itinerary
    {
        public string Name { get; set; }
        public string Description { get; set; }

        public int Id { get; set; }
        private static int nextId = 1;

        public Itinerary ()
        {
            Id = nextId;
            nextId++;
        }

        public Itinerary (string name, string description)
        {
            Name = name;
            Description = description;
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
