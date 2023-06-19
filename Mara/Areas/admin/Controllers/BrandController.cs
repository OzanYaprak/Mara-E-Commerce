using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mara.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class BrandController : Controller
    {
        private readonly IRepository<Brand> _brandRepository;

        public BrandController(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }




        [Route("MarkaYönetimi")]
        public IActionResult Index()
        {
            var brands = _brandRepository.GetAll().OrderBy(a=>a.ID);

            return View(brands);
        }

        [Route("YeniMarkaEkle")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("YeniMarkaEkle")]
        public IActionResult Create(Brand model)
        {
            _brandRepository.AddAsync(model);
            return RedirectToAction("Index");
        }

        [Route("MarkaGüncelle")]
        public async Task<IActionResult> Update(int id)
        {
            var updateModel = await _brandRepository.GetByAsync(a => a.ID == id);

            return View(updateModel);
        }
    }
}
