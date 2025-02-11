using BethanysPieShop.Data;
using BethanysPieShop.Models;

namespace BethanysPieShop.Repositories;

public class CategoryRepository : ICategoryRepository
{
    private readonly BethanysPieShopDbContext bethanysPieShopDbContext;

    public CategoryRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
    {
        this.bethanysPieShopDbContext = bethanysPieShopDbContext;
    }

    public IEnumerable<Category> AllCategories => this.bethanysPieShopDbContext.Categories.OrderBy(c => c.Name);
}
