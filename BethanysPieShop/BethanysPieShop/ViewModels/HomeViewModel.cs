using BethanysPieShop.Models;

namespace BethanysPieShop.ViewModels;

public class HomeViewModel
{
    public HomeViewModel(IEnumerable<Pie> piesOfTheWeek)
    {
        this.PiesOfTheWeek = piesOfTheWeek;
    }

    public IEnumerable<Pie> PiesOfTheWeek { get; }
}
