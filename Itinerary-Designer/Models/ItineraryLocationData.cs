namespace Trips.Models
{
    public class ItineraryLocationData
    {
        public int ItineraryId { get; set; }
        public Itinerary Itinerary { get; set; }

        public int LocationDataId { get; set; }
        public LocationData LocationData { get; set; }
    }
}