using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

public class ContactController : Controller
{
    public IActionResult Index()
    {
        return View();
    }

}
