using Microsoft.AspNetCore.Mvc;

namespace Sales.Controllers;

public class SellersController : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}