using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers
{
    public class AboutController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Chef));
        }

        public IActionResult Chef()
        {
            ViewData["Title"] = "Chef James Thew - Master Culinary Artist";
            return View();
        }

        public IActionResult Classes()
        {
            ViewData["Title"] = "Cookery Classes - Chef James Thew";
            return View();
        }

        public IActionResult Mission()
        {
            ViewData["Title"] = "Our Mission - Chef James Thew";
            return View();
        }

    }
}
