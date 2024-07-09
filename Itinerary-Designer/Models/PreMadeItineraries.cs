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
                        Name = "Rio Novo",
                        Address = "Santa Croce, 278, 30135 Venezia VE, Italy",
                        Category = "Restaurant",
                        PricePerPerson = 25,
                        Description = "Casual venue featuring seafood, pasta & pizzas, plus terrace dining with canal views.",
                        Phone = "+39 041 711007"
                    },

                    new LocationData
                    {
                        Name = "Impronta",
                        Address = "Sestiere Dorsoduro, 3815, 30123 Venezia VE, Italy",
                        Category = "Restaurant",
                        PricePerPerson = 28,
                        Description = "Seasonally focused meals with a creative twist in a contemporary restaurant & wine bar.",
                        Phone = "+39 041 275 0386"  
                    },

                    new LocationData
                    {
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
                Name = "Bars on Bars",
                LocationDatas = new List<LocationData>
                {
                    new LocationData
                    {
                        Name = "Irish Pub Santa Lucia",
                        Address = "Rio Terà Lista di Spagna, Campo San Geremia, 282/b, 30121 Venezia VE, Italy",
                        Category = "Bar",
                        PricePerPerson = 18.50,
                        Description = "Compact hangout offering beer, sandwiches & snacks in a traditional, unpretentious atmosphere.",
                        Phone = "+39 041 524 2880"
                    },
                    
                    new LocationData
                    {
                        Name = "Bar Longhi",
                        Address = "Campiello Traghetto, 2467, 30124 Venezia VE, Italy",
                        Category = "Bar",
                        PricePerPerson = 19,
                        Description = "Stylish, old-world hotel cocktail bar with views of the Grand Canal & city landmarks.",
                        Phone = "+39 041 794611"
                    },
                    
                    new LocationData
                    {
                        Name = "Il Mercante",
                        Address = "Fondamenta Frari, 2564, 30125 Venezia VE, Italy",
                        Category = "Bar",
                        PricePerPerson = 20,
                        Description = "Classy bar with an old-world style and sophisticated feel.",
                        Phone = "+39 041 794611"
                    }
                }

            },

            new Itinerary
            {
                Id = 3,
                Name = "Park Party",
                LocationDatas = new List<LocationData>
                {
                    new LocationData
                    {
                        Name = "Venice Paw Park",
                        Address = "Riva degli Schiavoni, 30303 Venezia VE, Italy",
                        Category = "Park",
                        PricePerPerson = 0,
                        Description = "Fenced dog park with a beach with on-site parking, picnic tables, showers & drinking fountains.",
                        Phone = "N/A"
                    },
                    
                    new LocationData
                    {
                        Name = "Giardini Papadopoli",
                        Address = "30135 Sestriere Santa Croce, Venezia Metropolitan City of Venice, Italy",
                        Category = "Park",
                        PricePerPerson = 0,
                        Description = "Giardino Papadopoli is a terraced garden filled with shade trees in the Venetian sestiere of Santa Croce, between the Venezia Santa Lucia train station and Piazzale Roma.",
                        Phone = "+39 041 274 8111"
                    },
                    
                    new LocationData
                    {
                        Name = "Parco delle Rimembranze",
                        Address = "Parco Rimembranze S.Elena, 30132 Venezia VE, Italy",
                        Category = "Park",
                        PricePerPerson = 0,
                        Description = "Scenic retreat featuring grassy spaces, pathways, pine trees & benches facing the water.",
                        Phone = "N/A"
                    }
                }

            }

        };
    }

}