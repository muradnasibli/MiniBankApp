using Microsoft.AspNetCore.Mvc;

namespace MiniBankApp.API.Controllers;

public class AccountContoller : Controller
{
    // GET
    public IActionResult Index()
    {
        return View();
    }
}