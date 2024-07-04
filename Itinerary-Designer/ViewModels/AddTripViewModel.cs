using System.ComponentModel.DataAnnotations;

namespace Itinerary.ViewModel;

public class AddTripViewModel
{
    [Required(ErrorMessage = "Trip name is required.")]
    [StringLength(50, ErrorMessage = "Trip name cannot be longer than 50 characters.")]
    public string? Name { get; set; }

}
