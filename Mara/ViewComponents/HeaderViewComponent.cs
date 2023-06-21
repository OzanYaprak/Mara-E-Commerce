using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace Mara.ViewComponents
{
    public class HeaderViewComponent : ViewComponent
    {
        IRepository<Category> _categoryRepository;

        public HeaderViewComponent(IRepository<Category> categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public IViewComponentResult Invoke()
        {
            var categories = _categoryRepository.GetAll().Include(a=>a.SubCategories).OrderBy(a=>a.ID);

            return View(categories);
        }
    }
}
