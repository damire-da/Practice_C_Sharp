using Microsoft.AspNetCore.Mvc;
using OnlineBank.Models;
using System.Diagnostics;

namespace OnlineBank.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        BankContext db;

        public HomeController(BankContext context)
        {
            db = context;
        }



        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Deposit()
        {
            return View(db.Deposits.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}