using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Kikea.Areas.Admin.Controllers
{
    [Area("Admin"),Authorize]
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/admin/giris"),AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/admin/giris"), AllowAnonymous]
        public IActionResult Login(string AdminUsername, string AdminPassword, string ReturnUrl)
        {
            return View();
        }
    }
}
