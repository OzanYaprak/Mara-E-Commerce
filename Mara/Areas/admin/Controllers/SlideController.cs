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
            //create action'nun view kısmında olan form içerisinden gönderilen bir form files var ise bu bloğa gir (resim vb.)
            if (Request.Form.Files.Any())
            {
                //eğer aşağıdaki blok içerisinde yazılmış olan konumda bir "slideimages" klasörü yok ise..
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "slideimages")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "slideimages")); //Burada o konumda "slideimages" adında yeni bir klasör oluştur.
                }

                //dosya adı kayıt edilirken aynı isimde olmamasını sağlamak için aşağıda, repo üzerinden bütün slideların sayısını string olarak çektik ve her yeni eklemede +1 eklenmesini sağladık, bu şekilde dosya isimleri aynı olmayacak.
                string dosyaAdi = (_slideRepository.GetAll().Count() + 1) + Request.Form.Files["SlidePicture"].FileName;

                //yukarıdan gelen dosya adını belirtilen directory de kayıt et 
                using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "slideimages", dosyaAdi), FileMode.Create))
                {
                    await Request.Form.Files["SlidePicture"].CopyToAsync(stream); //<---- formdan gelen dosyayı kayıt et
                }
                
                model.SlidePicture = "/slideimages/" + dosyaAdi; // <----- Veri tabanında gözükeceği ad düzeni..

            }

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
            
            if (Request.Form.Files.Any())
            {            
                if (!Directory.Exists(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "slideimages")))
                {
                    Directory.CreateDirectory(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "slideimages")); //Burada o konumda "slideimages" adında yeni bir klasör oluştur.
                }
                
                string dosyaAdi = (_slideRepository.GetAll().Count() + 1) + Request.Form.Files["SlidePicture"].FileName;

                using (FileStream stream = new FileStream(Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", "slideimages", dosyaAdi), FileMode.Create))
                {
                    await Request.Form.Files["SlidePicture"].CopyToAsync(stream);
                }

                model.SlidePicture = "/slideimages/" + dosyaAdi;
            }

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
