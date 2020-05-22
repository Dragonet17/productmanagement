using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using ProductManagement.Models;
using System.Diagnostics;
using ApplicationIdentity.Controllers;
using ApplicationIdentity.Entities;
using ProductManagement.Database.Database;

namespace ProductManagement.Controllers
{
    public class HomeController : ApplicationUserController
    {
        private readonly ILogger<HomeController> _logger;
        public HomeController(UserManager<ApplicationUser> userManager, SignInManager<ApplicationUser> signInManager,ILogger<HomeController> logger)
            : base(userManager, signInManager)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
