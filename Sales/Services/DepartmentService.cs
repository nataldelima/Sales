using Sales.Data;
using Sales.Models;

namespace Sales.Services;

public class DepartmentService
{
    private readonly SalesContext _context;

    public DepartmentService(SalesContext context)
    {
        _context = context;
    }

    public List<Department> FindAll()
    {
        return _context.Department.OrderBy(x => x.Name).ToList();
    }
}