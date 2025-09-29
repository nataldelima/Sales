using Microsoft.EntityFrameworkCore;
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

    public async Task<List<Department>> FindAllAsync()
    {
        return await _context.Department.OrderBy(x => x.Name).ToListAsync();
    }
}