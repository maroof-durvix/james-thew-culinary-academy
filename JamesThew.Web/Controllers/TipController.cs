using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

public class TipController : Controller
{
    public IActionResult Premium()
    {
        return View();
    }

    public IActionResult Details()
    {
        return View();
    }

    public IActionResult Free()
    {
        return View();
    }

}
