using BethanysPieShop.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components;

public class CategoryMenu : ViewComponent
{
    private readonly ICategoryRepository categoryRepository;

    public CategoryMenu(ICategoryRepository categoryRepository)
    {
        this.categoryRepository = categoryRepository;
    }

    public IViewComponentResult Invoke()
    {
        var categories = this.categoryRepository.AllCategories.OrderBy(c => c.Name);

        return View(categories);
    }
}
