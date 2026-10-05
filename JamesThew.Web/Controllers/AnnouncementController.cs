using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

public class AnnouncementController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
