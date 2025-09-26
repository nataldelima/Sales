using Sales.Data;
using Sales.Models;

namespace Sales.Services;

public class SellerService
{
    private readonly SalesContext _context;

    public SellerService(SalesContext context)
    {
        _context = context;
    }

    public List<Seller> FindAll()
    {
        return _context.Seller.ToList();
    }

    public void Insert(Seller obj)
    {
        _context.Add(obj);
        _context.SaveChanges();
    }
    
}