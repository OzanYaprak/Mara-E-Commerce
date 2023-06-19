using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mara.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class CategoryController : Controller
    {
        IRepository<Category> _categoryRepository;

        public CategoryController(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }




        [Route("KategoriYönetimi")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
