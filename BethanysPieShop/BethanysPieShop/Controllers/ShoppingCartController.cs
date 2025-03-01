using BethanysPieShop.Repositories;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Controllers;

public class ShoppingCartController : Controller
{
    private readonly IPieRepository pieRepository;
    private readonly IShoppingCart shoppingCart;

    public ShoppingCartController(IPieRepository pieRepository, IShoppingCart shoppingCart)
    {
        this.pieRepository = pieRepository;
        this.shoppingCart = shoppingCart;
    }

    public ViewResult Index()
    {
        var items = this.shoppingCart.GetShoppingCartItems();
        this.shoppingCart.ShoppingCartItems = items;

        var shoppingCartViewModel = new ShoppingCartViewModel(this.shoppingCart, this.shoppingCart.GetShoppingCartTotal());

        return View(shoppingCartViewModel);
    }

    public RedirectToActionResult AddToShoppingCart(int pieId)
    {
        var selectedPie = this.pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

        if (selectedPie != null)
        {
            this.shoppingCart.AddToCart(selectedPie);
        }

        return RedirectToAction("Index");
    }

    public RedirectToActionResult RemoveFromShoppingCart(int pieId) 
    {
        var selectedPie = this.pieRepository.AllPies.FirstOrDefault(p => p.PieId == pieId);

        if (selectedPie != null) 
        {
            this.shoppingCart.RemoveFromCart(selectedPie);
        }

        return RedirectToAction("Index");
    }
}
