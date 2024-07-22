namespace Trips.Models
{
    public class Itinerary
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public DateTime Date { get; set; }
        public int NumberOfPets { get; set; }
        public List<LocationData> LocationDatas { get; set; } = new List<LocationData>();
        public List<ItineraryLocationData> ItineraryLocationDatas { get; set; } = new List<ItineraryLocationData>();
        public decimal TotalCostPerItinerary { get; set; }
        public decimal TotalCostPerItineraryEUR { get; set; }
        public string UserId { get; set; }

        // Ensure TotalCostForAllLocations has both get and set accessors
        public decimal TotalCostForAllLocations { get; set; }
        public decimal TotalCostForAllPeople { get; set; }
        public int NumberOfPeople { get; set; }
        public decimal TotalCostInEur { get; set; }

        public Itinerary() { }

        public Itinerary(string name, List<LocationData> locationData)
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
