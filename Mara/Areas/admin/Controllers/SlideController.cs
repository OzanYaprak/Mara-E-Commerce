using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Mara.Areas.admin.Controllers
{
    
    [Area("admin"), Authorize]
    public class SlideController : Controller
    {
        IRepository<Slide> _slideRepository;

        public SlideController(IRepository<Slide> slideRepository)
        {
            _slideRepository = slideRepository;
        }




        [Route("SlaytYönetimi")]
        public IActionResult Index()
        {
            var slides = _slideRepository.GetAll().OrderBy(a => a.ID);

            return View(slides);
        }




        [Route("YeniSlaytEkle")]
        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        [Route("YeniSlaytEkle")]
        public async Task<IActionResult> Create(Slide model)
        {
            await _slideRepository.AddAsync(model);
            return RedirectToAction("Index");
        }




        [HttpGet]
        [Route("SlaytGüncelle")]
        public async Task<IActionResult> Update(int id)
        {
            var getSlideToUpdate = await _slideRepository.GetByAsync(a => a.ID == id);

            return View(getSlideToUpdate);
        }

        [HttpPost]
        [Route("SlaytGüncelle")]
        public async Task<IActionResult> Update(Slide model)
        {
            await _slideRepository.UpdateAsync(model);

            return RedirectToAction("Index");
        }




        [Route("SlaytSil")]
        public async Task<IActionResult> Delete(int id)
        {
            var slide = await _slideRepository.GetByAsync(x => x.ID == id);

            await _slideRepository.DeleteAsync(slide);

            return RedirectToAction("Index");
        }
    }
}
