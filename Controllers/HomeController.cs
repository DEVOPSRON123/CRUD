using CRUD.Models;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using System.Security.Claims;

namespace CRUD.Controllers
{
    
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        [Authorize]
        public IActionResult Index()
        {
            ClaimsPrincipal claimuser1 = new ClaimsPrincipal();
            claimuser1 = HttpContext.User;
            if (claimuser1.Identity.IsAuthenticated)
            {
                ViewData["Login"] = true;
                return View();
            }
            return RedirectToAction("Login");
        }
        [Authorize]
        public IActionResult Privacy()
        {
            ViewData["Login"] = true;
            return View();
        }
        public IActionResult Contact()
        {
            ClaimsPrincipal claimuser1 = new ClaimsPrincipal();
            claimuser1 = HttpContext.User;
            if (claimuser1.Identity.IsAuthenticated)
            {
                ViewData["Login"] = true;
                return View();
            }
            ViewData["Login"] = false;
            return View();
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult Login()
        {
            
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> Login(string username,string password)
        {

            var claim = new List<Claim>
            {
                new Claim(ClaimTypes.Name,username.ToString())
            };
            var identity = new ClaimsIdentity(claim, CookieAuthenticationDefaults.AuthenticationScheme);
            var principal = new ClaimsPrincipal(identity);
            var props = new AuthenticationProperties()
            {
                AllowRefresh= true,
                IsPersistent = true
            };
            HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal, props).Wait();
            return RedirectToAction("Department");
        }
        [Authorize]
        public IActionResult Logout()
        {

            HttpContext.SignOutAsync();
            return RedirectToAction("Login");
        }
       

        [Authorize]
        public IActionResult Department(ClaimsPrincipal claimuser)
        {
            ClaimsPrincipal claimuser1 = new ClaimsPrincipal();
            claimuser1=HttpContext.User;
            if (claimuser1.Identity.IsAuthenticated)
            {
                ViewData["Login"] = true;
                return View();
            }
            return RedirectToAction("Login");
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}