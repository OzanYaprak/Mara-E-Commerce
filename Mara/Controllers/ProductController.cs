using Microsoft.AspNetCore.Mvc;

namespace Mara.Controllers
{
    public class ProductController : Controller
    {

        [Route("/Erkek")]
        public IActionResult MensProduct()
        {
            ViewBag.MenuIndex = 3;

            return View();
        }

        [Route("/Kadın")]
        public IActionResult WomensProduct()
        {
            ViewBag.MenuIndex = 4;

            return View();
        }
    }
}
