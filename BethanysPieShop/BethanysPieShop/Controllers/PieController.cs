using BethanysPieShop.Repositories;
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
        return View(this.pieRepository.AllPies);
    }
}
