using BethanysPieShop.Models;

namespace BethanysPieShop.Repositories;

public class MockCategoryRepository : ICategoryRepository
{
    public IEnumerable<Category> AllCategories =>
    [
        new() {
            CategoryId = 1,
            Name = "Fruit pies",
            Description = "All-fruity pies",
        },
        new()
        {
            CategoryId = 2,
            Name = "Cheese cakes",
            Description = "Cheesy all the way",
        },
        new()
        {
            CategoryId = 3,
            Name = "Seasonal pies",
            Description = "Get in the mood for a seasonal pie",
        }
    ];
}
