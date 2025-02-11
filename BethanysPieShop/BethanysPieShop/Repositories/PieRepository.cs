using BethanysPieShop.Data;
using BethanysPieShop.Models;
using Microsoft.EntityFrameworkCore;

namespace BethanysPieShop.Repositories;

public class PieRepository : IPieRepository
{
    private readonly BethanysPieShopDbContext bethanysPieShopDbContext;

    public PieRepository(BethanysPieShopDbContext bethanysPieShopDbContext)
    {
        this.bethanysPieShopDbContext = bethanysPieShopDbContext;
    }

    public IEnumerable<Pie> AllPies 
    {
        get
        {
            return this.bethanysPieShopDbContext.Pies.Include(c => c.Category);
        }
    }

    public IEnumerable<Pie> PieOfTheWeek 
    {
        get
        {
            return this.bethanysPieShopDbContext.Pies.Include(c => c.Category).Where(p => p.IsPieOfTheWeek);
        }
    }

    public Pie? GetPieById(int pieId)
    {
        return this.bethanysPieShopDbContext.Pies.FirstOrDefault(p => p.PieId == pieId);
    }

    public IEnumerable<Pie> SearchPies(string searchQuery)
    {
        throw new NotImplementedException();
    }
}
