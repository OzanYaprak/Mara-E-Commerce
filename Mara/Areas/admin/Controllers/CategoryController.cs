using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

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
            var brands = _categoryRepository.GetAll().Include(a=>a.ParentCategory).OrderBy(a => a.ID);

            return View(brands);
        }




        [Route("YeniKategoriEkle")]
        public IActionResult Create()
        {
            ViewBag.Categories = _categoryRepository.GetAll()
                .OrderBy(a => a.CategoryName)
                .Select(a => new SelectListItem
                {
                    Value = a.ID.ToString(),
                    Text = a.CategoryName,
                });

            return View();
        }

        [HttpPost]
        [Route("YeniKategoriEkle")]
        public async Task<IActionResult> Create(Category model)
        {
            await _categoryRepository.AddAsync(model);
            return RedirectToAction("Index");
        }




        [HttpGet]
        [Route("KategoriGüncelle")]
        public async Task<IActionResult> Update(int id)
        {
            ViewBag.Categories = _categoryRepository.GetAll()
                .OrderBy(a => a.CategoryName)
                .Select(a => new SelectListItem
                {
                    Value = a.ID.ToString(),
                    Text = a.CategoryName,
                });

            var getCategoryToUpdate = await _categoryRepository.GetByAsync(a => a.ID == id);

            return View(getCategoryToUpdate);
        }

        [HttpPost]
        [Route("KategoriGüncelle")]
        public async Task<IActionResult> Update(Category model)
        {
            await _categoryRepository.UpdateAsync(model);

            return RedirectToAction("Index");
        }




        [Route("KategoriSil")]
        public async Task<IActionResult> Delete(int id)
        {
            var category = await _categoryRepository.GetByAsync(x => x.ID == id);

            await _categoryRepository.DeleteAsync(category);

            return RedirectToAction("Index");
        }
    }
}
