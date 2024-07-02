using System;

namespace Trips.Models
{
    public class Trip
    {
        public string ItineraryName { get; set; }

        public int PeopleCount { get; set; }

        public double CalculatedCost { get; set; }
        public List<string> SelectedEvents { get; set; } = new List<string>();

        public int Id { get; set; }
        private static int nextId = 1;

        public Trip()
        {
            Id = nextId;
            nextId++;
        }

        public Trip(string tripname)
        {
            ItineraryName = tripname;
            Id = nextId;
            nextId++;
        }

        public override int GetHashCode()
        {
            return HashCode.Combine(Id);
        }
    }
}


// https://github.com/Carolista/CodingEventsCSharp/tree/models