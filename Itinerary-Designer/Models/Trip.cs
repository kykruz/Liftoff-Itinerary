using System;

namespace Trips.Models
{
    public class Trip
    {
        public string TripName { get; set; }

        public int PeopleCount { get; set; }

        public double CalculatedCost { get; set; }
        public List<string> SelectedEvents { get; set; } = new List<string>();

        // switch this to Itineraries

        public int Id { get; set; }
        private static int nextId = 1;

        public Trip()
        {
            Id = nextId;
            nextId++;
        }

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


