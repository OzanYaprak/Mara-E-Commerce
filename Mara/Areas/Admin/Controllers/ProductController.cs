using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mara.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class ProductController : Controller
    {
        IRepository<Product> _productRepository;

        public ProductController(IRepository<Product> productRepository)
        {
            _productRepository = productRepository;
        }





        [Route("ÜrünYönetimi")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
