using BusinessLayer.Repositories;
using DataAccessLayer.Entities;
using Mara.Tools;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;

namespace Kikea.Areas.admin.Controllers
{
    [Area("admin"),Authorize]
    public class HomeController : Controller
    {
        IRepository<Admin> _adminRepository;

        public HomeController(IRepository<Admin> adminRepository)
        {
            _adminRepository = adminRepository;
        }

        [Route("/admin")]
        public IActionResult Index()
        {
            return View();
        }





        [Route("/admin/giris"),AllowAnonymous]
        public IActionResult Login(string ReturnUrl)
        {
            ViewBag.ReturnUrl = ReturnUrl;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("/admin/giris"), AllowAnonymous]
        public async Task<IActionResult> Login(string AdminUsername, string AdminPassword, string ReturnUrl)
        {
            string md5Password = GeneralTools.getMD5(AdminPassword);

            var admin = await _adminRepository.GetByAsync(a => a.AdminUsername == AdminUsername && a.AdminPassword == md5Password) ?? null;

            if (admin != null)
            {

                List<Claim> claims = new List<Claim>
                {
                    new Claim(ClaimTypes.PrimarySid, admin.ID.ToString()),
                    new Claim(ClaimTypes.Name, admin.AdminName+" "+admin.AdminSurname)
                    //new Claim("LastLogDate", admin.LastLoginIPNo)
                };

                ClaimsIdentity claimsIdentity = new ClaimsIdentity(claims, "MaraAdmin");

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(claimsIdentity), new AuthenticationProperties { IsPersistent = true });

                admin.LastLoginDate = DateTime.Now.Date;
                admin.LastLoginIPNo = HttpContext.Connection.RemoteIpAddress.ToString();

                await _adminRepository.UpdateAsync(admin, a => a.LastLoginDate, b => b.LastLoginIPNo);

                //List<Claim> claimss = new List<Claim>
                //{
                //    new Claim("LastLogDate", admin.LastLoginDate.ToShortTimeString())
                //};


                if (string.IsNullOrEmpty(ReturnUrl))
                {
                    return Redirect("/admin");
                }

                return Redirect(ReturnUrl);

            }

            TempData["LoginError"] = "Kullanıcı Adı Veya Şifreniz Hatalıdır";

            return View();

        }






        [Route("/admin/cikis")]
        public async Task<IActionResult> Logout(string ReturnUrl)
        {
            await HttpContext.SignOutAsync();

            return Redirect("/admin");
        }
    }
}
