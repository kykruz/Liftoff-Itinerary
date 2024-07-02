namespace Itinerary_Designer.ViewModels;

public class CreateItineraryViewModel
{
    public bool IsChecked { get; set; }
    public List<Option> Options { get; set; }
    public List<int> SelectedOptionIds { get; set; }
}

public class Option
{
}