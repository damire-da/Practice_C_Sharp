using Microsoft.AspNetCore.Mvc;
using OnlineBank.Models;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;
using OnlineBank.ViewModels;

using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;

namespace OnlineBank.Controllers
{
    public class AccountController : Controller
    {
        private BankContext db;

        public AccountController(BankContext context)
        {
            db = context;
        }
        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginModel model)
        {
            if (ModelState.IsValid)
            {
                Client client = await db.Clients.FirstOrDefaultAsync(c => c.Email == model.Email && c.Password == model.Password);
                if(client != null)
                {
                    await Authenticate(model.Email); //аутентификация
                    return RedirectToAction("Index", "Home");
                }
                ModelState.AddModelError("", "Некорректные логин и(или) пароль!");
            }
            
            return View(model);
        }
        [HttpGet]
        public IActionResult Register()
        {
            return View();
        }
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterModel model)
        {
            if (ModelState.IsValid)
            {
                Client client = await db.Clients.FirstOrDefaultAsync(c => c.Email == model.Email);
                if (client == null)
                {
                    //add client in db
                    client = new Client { Email = model.Email, Password = model.Password, Name = model.Name, Age = model.Age };
                    Deposit1 deposit = await db.Deposits.FirstOrDefaultAsync(d => d.Name == null);
                    await db.SaveChangesAsync();

                    await Authenticate(model.Email);

                    return RedirectToAction("Index", "Home");
                }
                else
                    ModelState.AddModelError("", "Неккоректные логин и(или) пароль!");
            }
            return View(model);
        }

        private async Task Authenticate(string clientName)
        {
            var claims = new List<Claim>
            {
                new Claim(ClaimsIdentity.DefaultNameClaimType, clientName)
            };
            ClaimsIdentity id = new ClaimsIdentity(claims, "ApplicationCookie", ClaimsIdentity.DefaultNameClaimType, ClaimsIdentity.DefaultNameClaimType);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(id));
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Login", "Account");
        }
    }
}
