using AirTickedSales.ViewModel.Catalog.System;
using Microsoft.AspNetCore.Mvc;

namespace AirTickedSales.WebAdminApp.Controllers
{
    public class UserController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        [HttpGet]
        public IActionResult Login ()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginRequest request)
        {
            return View();
        }
    }
}