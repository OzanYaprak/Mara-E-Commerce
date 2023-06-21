using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mara.ViewComponents
{
    public class HeaderSecondViewComponent : ViewComponent
    {
        IRepository<Category> _categoryRepository;

        public HeaderSecondViewComponent(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }


        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAll().Include(x=>x.SubCategories).OrderBy(x=>x.ID);

            return View(categories);
        }
    }
}
