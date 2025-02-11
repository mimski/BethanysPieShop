using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Data;

public class BethanysPieShopDbContext : DbContext
{
    public BethanysPieShopDbContext(DbContextOptions<BethanysPieShopDbContext> options) 
        : base(options)
    {
    }

    public DbSet<Category> Categories { get; set; }

    public DbSet<Pie> Pies { get; set; }
}
