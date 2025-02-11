using BethanysPieShop.Repositories;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class PieController : Controller
{
    private readonly IPieRepository pieRepository;
    private readonly ICategoryRepository categoryRepository;

    public PieController(IPieRepository pieRepository, ICategoryRepository categoryRepository)
    {
        this.pieRepository = pieRepository;
        this.categoryRepository = categoryRepository;
    }

    public IActionResult List()
    {
        var viewModel = new PieListViewModel
        (
            pies: this.pieRepository.AllPies,
            currentCategory: "Cheese cakes"
        );

        return View(viewModel);
    }
}
