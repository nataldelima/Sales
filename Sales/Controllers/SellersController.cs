using Microsoft.AspNetCore.Mvc;
using Sales.Models;
using Sales.Services;

namespace Sales.Controllers;

public class SellersController : Controller
{
    private readonly SellerService _sellerService;

    public SellersController(SellerService sellerService)
    {
        _sellerService = sellerService;
    }
    
    // GET
    public IActionResult Index()
    {
        var list = _sellerService.FindAll();
        return View(list);
    }
    
    
    public IActionResult Create()
    {
        ViewBag.Departments = _sellerService.FindAllDepartments();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(Seller seller)
    {
        if (!ModelState.IsValid)
        {
            Console.WriteLine("ModelState inválido!");
            ViewBag.Departments = _sellerService.FindAllDepartments();
            return View(seller);
        }
        _sellerService.Insert(seller);
        return RedirectToAction(nameof(Index));
    }
}