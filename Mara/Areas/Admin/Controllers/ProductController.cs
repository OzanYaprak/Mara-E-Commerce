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
            var products = _productRepository.GetAll().OrderBy(a => a.ID);

            return View(products);
        }




        [Route("YeniÜrünEkle")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("YeniÜrünEkle")]
        public async Task<IActionResult> Create(Product model)
        {
            await _productRepository.AddAsync(model);
            return RedirectToAction("Index");
        }




        [HttpGet]
        [Route("ÜrünGüncelle")]
        public async Task<IActionResult> Update(int id)
        {
            var getProductToUpdate = await _productRepository.GetByAsync(a => a.ID == id);

            return View(getProductToUpdate);
        }

        [HttpPost]
        [Route("ÜrünGüncelle")]
        public async Task<IActionResult> Update(Product model)
        {
            await _productRepository.UpdateAsync(model);

            return RedirectToAction("Index");
        }




        [Route("ÜrünSil")]
        public async Task<IActionResult> Delete(int id)
        {
            var product = await _productRepository.GetByAsync(x => x.ID == id);

            await _productRepository.DeleteAsync(product);

            return RedirectToAction("Index");
        }
    }
}
