using BethanysPieShop.Repositories;
using BethanysPieShop.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace BethanysPieShop.Components;

public class ShoppingCartSummary : ViewComponent
{
    private readonly IShoppingCart shoppingCart;

    public ShoppingCartSummary(IShoppingCart shoppingCart)
    {
        this.shoppingCart = shoppingCart;
    }

    public IViewComponentResult Invoke()
    {
        var items = this.shoppingCart.GetShoppingCartItems();
        this.shoppingCart.ShoppingCartItems = items;

        var shoppingCartViewModel = new ShoppingCartViewModel(this.shoppingCart, this.shoppingCart.GetShoppingCartTotal());

        return View(shoppingCartViewModel);
    }
}
