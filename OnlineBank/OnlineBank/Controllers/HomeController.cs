using Microsoft.AspNetCore.Mvc;
using OnlineBank.Models;
using System.Diagnostics;
using Microsoft.AspNetCore.Authorization;

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


        [Authorize]
        public IActionResult Index()
        {
            return View();
            //return Content(User.Identity.Name);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public IActionResult Deposit()
        {
            return View(db.Deposits.ToList());
        }

        public IActionResult DepositInfo()
        {
            return View(db.DepositsInfo.ToList());
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }

        [HttpGet]
        public IActionResult Arrange(int? id)
        {
            if (id == null) return RedirectToAction("Index");
            ViewBag.Depositid = id;

            return View(db.DepositsInfo.ToList());
        }
        [HttpPost]
        public string Arrange(Deposit1 deposit)
        {
            //deposit.Client=
            //Deposit1 deposit1 = new() 
            //{
            //    Id = deposit.Id,
            //    Name = deposit.Name,
            //    Percent = deposit.Percent,
            //    Info = deposit.Info
                
            //};
            db.Deposits.Add(deposit);
            
            
            db.SaveChanges();
            return "Вклад успешно оформлен. Детали вклада" +
                " можно посмотреть во вкладке 'Мои вклады'";
        }
    }
}