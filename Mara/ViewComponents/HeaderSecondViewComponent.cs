using Microsoft.AspNetCore.Mvc;

namespace Mara.ViewComponents
{
    public class HeaderSecondViewComponent : ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
