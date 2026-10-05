using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

public class FaqController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
