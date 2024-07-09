namespace Trips.Models;

public class PreMadeItineraries
{

public static List<Itinerary> GetPreMadeItineraries()
    {
        return new List<Itinerary>
        {
            new Itinerary
            {
                Id = 1,
                Name = "Restaurant Tour",
                LocationDatas = new List<LocationData>
                {
                    new LocationData
                    {
                        Id = 1,
                        Name = "Rio Novo",
                        Address = "Santa Croce, 278, 30135 Venezia VE, Italy",
                        Category = "Restaurant",
                        PricePerPerson = 25,
                        Description = "Casual venue featuring seafood, pasta & pizzas, plus terrace dining with canal views.",
                        Phone = "+39 041 711007"
                    },

                    new LocationData
                    {
                        Id = 2,
                        Name = "Impronta",
                        Address = "Sestiere Dorsoduro, 3815, 30123 Venezia VE, Italy",
                        Category = "Restaurant",
                        PricePerPerson = 28,
                        Description = "Seasonally focused meals with a creative twist in a contemporary restaurant & wine bar.",
                        Phone = "+39 041 275 0386"  
                    },

                    new LocationData
                    {
                        Id = 3,
                        Name = "Osteria Antico Giardinetto",
                        Address = "Calle dei Morti, 2253, 30135 Venezia VE, Italy",
                        Category = "Restaurant",
                        PricePerPerson = 26,
                        Description = "Cozy, family-run restaurant with a rustic interior & a fish-centric menu of Med/Venetian dishes",
                        Phone = "+39 041 722882"
                    }

                
                    
                }

            },
            
            new Itinerary
            {
                Id = 2,
                Name = "Restaurant Tour",
                LocationDatas = new List<LocationData>
                {
                    new LocationData
                    {
                        Id = 1,
                        Name = "Rio Novo",
                        Address = "Santa Croce, 278, 30135 Venezia VE, Italy",
                        Category = "Restaurant",
                        PricePerPerson = 25,
                        Description = "Casual venue featuring seafood, pasta & pizzas, plus terrace dining with canal views.",
                        Phone = "+39 041 711007"
                    }
                    
                }

            }

        };
    }

}