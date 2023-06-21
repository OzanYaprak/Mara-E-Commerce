using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;

namespace Kikea.Controllers
{
    public class HomeController : Controller
    {
        
        public IActionResult Index()
        {
            ViewBag.MenuIndex = 0;

            return View();
        }

        [Route("/Hakkimizda")]
        public IActionResult AboutUs()
        {
            ViewBag.MenuIndex = 1;

            return View();
        }

        [Route("/İletişim")]
        public IActionResult Contact()
        {
            ViewBag.MenuIndex = 2;

            return View();
        }
    }
}