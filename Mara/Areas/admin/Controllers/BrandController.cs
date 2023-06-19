using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mara.Areas.admin.Controllers
{
    [Area("admin"), Authorize]
    public class BrandController : Controller
    {
        IRepository<Brand> _brandRepository;

        public BrandController(IRepository<Brand> brandRepository)
        {
            _brandRepository = brandRepository;
        }




        [Route("MarkaYönetimi")]
        public IActionResult Index()
        {
            var brands = _brandRepository.GetAll().OrderBy(a => a.ID);

            return View(brands);
        }




        [Route("YeniMarkaEkle")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("YeniMarkaEkle")]
        public async Task<IActionResult> Create(Brand model)
        {
            await _brandRepository.AddAsync(model);
            return RedirectToAction("Index");
        }




        [HttpGet]
        [Route("MarkaGüncelle")]
        public async Task<IActionResult> Update(int id)
        {
            var getBrandToUpdate = await _brandRepository.GetByAsync(a => a.ID == id);

            return View(getBrandToUpdate);
        }

        [HttpPost]
        [Route("MarkaGüncelle")]
        public async Task<IActionResult> Update(Brand model)
        {
            await _brandRepository.UpdateAsync(model);

            return RedirectToAction("Index");
        }




        [Route("MarkaSil")]
        public async Task<IActionResult> Delete(int id)
        {
            var brand = await _brandRepository.GetByAsync(x => x.ID == id);

            await _brandRepository.DeleteAsync(brand);

            return RedirectToAction("Index");
        }
    }
}
