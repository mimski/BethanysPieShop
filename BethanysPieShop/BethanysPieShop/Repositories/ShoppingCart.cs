using BethanysPieShop.Data;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Repositories;

public class ShoppingCart : IShoppingCart
{
    private readonly BethanysPieShopDbContext bethanysPieShopDbContext;

    public ShoppingCart(BethanysPieShopDbContext bethanysPieShopDbContext)
    {
        this.bethanysPieShopDbContext = bethanysPieShopDbContext;
    }

    public string? ShoppingCartId { get; set; }

    public List<ShoppingCartItem> ShoppingCartItems { get; set; } = default!;

    public static ShoppingCart GetCart(IServiceProvider serviceProvider)
    {
        ISession? session = serviceProvider.GetRequiredService<IHttpContextAccessor>()?.HttpContext?.Session;

        BethanysPieShopDbContext context = serviceProvider.GetService<BethanysPieShopDbContext>() ?? throw new Exception("Error initializing");

        string cartId = session?.GetString("CartId") ?? Guid.NewGuid().ToString();

        session?.SetString("CartId", cartId);

        return new ShoppingCart(context) { ShoppingCartId = cartId };
    }

    public void AddToCart(Pie pie)
    {
        var shoppingCartItem =
                  this.bethanysPieShopDbContext.ShoppingCartItem.SingleOrDefault(
                      s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

        if (shoppingCartItem == null)
        {
            shoppingCartItem = new ShoppingCartItem
            {
                ShoppingCartId = ShoppingCartId,
                Pie = pie,
                Amount = 1
            };

            this.bethanysPieShopDbContext.ShoppingCartItem.Add(shoppingCartItem);
        }
        else
        {
            shoppingCartItem.Amount++;
        }
        
        this.bethanysPieShopDbContext.SaveChanges();
    }

    public int RemoveFromCart(Pie pie)
    {
        var shoppingCartItem =
                    this.bethanysPieShopDbContext.ShoppingCartItem.SingleOrDefault(
                        s => s.Pie.PieId == pie.PieId && s.ShoppingCartId == ShoppingCartId);

        var localAmount = 0;

        if (shoppingCartItem != null)
        {
            if (shoppingCartItem.Amount > 1)
            {
                shoppingCartItem.Amount--;
                localAmount = shoppingCartItem.Amount;
            }
            else
            {
                this.bethanysPieShopDbContext.ShoppingCartItem.Remove(shoppingCartItem);
            }
        }

        this.bethanysPieShopDbContext.SaveChanges();

        return localAmount;
    }

    public void ClearCart()
    {
        var cartItems = this.bethanysPieShopDbContext
                .ShoppingCartItem
                .Where(cart => cart.ShoppingCartId == ShoppingCartId);

        this.bethanysPieShopDbContext.ShoppingCartItem.RemoveRange(cartItems);

        this.bethanysPieShopDbContext.SaveChanges();
    }

    public List<ShoppingCartItem> GetShoppingCartItems()
    {
        return ShoppingCartItems ??=
                      this.bethanysPieShopDbContext.ShoppingCartItem.Where(c => c.ShoppingCartId == ShoppingCartId)
                          .Include(s => s.Pie)
                          .ToList();
    }

    public decimal GetShoppingCartTotal()
    {
        var total = this.bethanysPieShopDbContext.ShoppingCartItem.Where(c => c.ShoppingCartId == ShoppingCartId)
               .Select(c => c.Pie.Price * c.Amount).Sum();

        return total;
    }
}
