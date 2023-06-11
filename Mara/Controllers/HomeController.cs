using Microsoft.AspNetCore.Mvc;

namespace Kikea.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

        [Route("/admin/giris")]
        public IActionResult AdminLogin()
        {
            return View();
        }

        [Route("/hakkimizda")]
        public IActionResult AboutUs()
        {
            return View();
        }
    }
}