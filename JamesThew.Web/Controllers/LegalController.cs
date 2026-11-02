using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers
{
    public class LegalController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Terms));
        }

        public IActionResult Terms()
        {
            ViewData["Title"] = "Terms of Service";
            return View();
        }

        public IActionResult Privacy()
        {
            ViewData["Title"] = "Privacy Policy";
            return View();
        }
    }
}
