using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

[Authorize(Roles = "Admin")]
public class AdminController : Controller
{
    public IActionResult RecipeForm() { return View(); }
    public IActionResult Feedback() { return View(); }
    public IActionResult Tips() { return View(); }
    public IActionResult Contests() { return View(); }
    public IActionResult Entries() { return View(); }
    public IActionResult Announcements() { return View(); }
    public IActionResult Recipes() { return View(); }
    public IActionResult Dashboard() { return View(); }
    public IActionResult Members() { return View(); }
    public IActionResult TipForm() { return View(); }
}
