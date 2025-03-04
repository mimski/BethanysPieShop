using BethanysPieShop.Models;
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

    public IActionResult List(string category)
    {
        IEnumerable<Pie> pies;
        string? currentCategory;

        if (string.IsNullOrEmpty(category))
        {
            pies = this.pieRepository.AllPies.OrderBy(p => p.PieId);
            currentCategory = "All pies";
        }
        else
        {
            pies = this.pieRepository.AllPies.Where(p => p.Category.Name == category)
                .OrderBy(p => p.PieId);
            currentCategory = this.categoryRepository.AllCategories.FirstOrDefault(c => c.Name == category)?.Name;
        }

        var viewModel = new PieListViewModel
        (
            pies: pies,
            currentCategory: currentCategory
        );

        return View(viewModel);
    }

    public IActionResult Details(int id) 
    { 
        var pie = this.pieRepository.GetPieById(id);

        if (pie == null)
        {
            return NotFound();
        }

        return View(pie);
    }
}
