using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

public class ContestController : Controller
{
    public IActionResult Active()
    {
        return View();
    }

    public IActionResult Winners()
    {
        return View();
    }

    public IActionResult Submit()
    {
        return View();
    }

}
