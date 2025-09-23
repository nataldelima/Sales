using System.Runtime.CompilerServices;
using Microsoft.AspNetCore.Mvc;
using Sales.Models;

namespace Sales.Controllers;

public class DepartmentsController : Controller
{
    // GET
    public IActionResult Index()
    {
        List<Department> list = new List<Department>();
        list.Add(new Department {Id = 1, Name = "Eletronics"});
        list.Add(new Department {Id = 2, Name = "Fashion"});
        
        return View(list);
    }
}