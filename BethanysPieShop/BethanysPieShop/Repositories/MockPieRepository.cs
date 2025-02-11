using BethanysPieShop.Models;

namespace BethanysPieShop.Repositories;

public class MockPieRepository : IPieRepository
{
    private readonly ICategoryRepository categoryRepository = new MockCategoryRepository();

    public IEnumerable<Pie> AllPies =>
    [
        new()
        {
            PieId = 1,
            Name = "Strawberry Pie",
            Price = 15.95M,
            ShortDescription = "Lorem Ipsum",
            LongDescription = "Lorem ipsum sit dolor.",
            Category = this.categoryRepository.AllCategories.ToList()[0],
            ImageUrl = "",
            InStock = true,
            IsPieOfTheWeek = false,
            ImageThumbnailUrl = ""
        },
        new()
        {
            PieId = 2,
            Name = "Cheese cake",
            Price = 18.95M,
            ShortDescription = "Lorem Ipsum",
            LongDescription = "Lorem ipsum sit dolor.",
            Category = this.categoryRepository.AllCategories.ToList()[0],
            ImageUrl = "",
            InStock = true,
            IsPieOfTheWeek = true,
            ImageThumbnailUrl = ""
        }
    ];

    public IEnumerable<Pie> PiesOfTheWeek
    {
        get
        {
            return AllPies.Where(p => p.IsPieOfTheWeek);
        }
    }

    public Pie? GetPieById(int pieId) => AllPies.FirstOrDefault(p => p.PieId == pieId);

    public IEnumerable<Pie> SearchPies(string searchQuery)
    {
        throw new NotImplementedException();
    }
}
