using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

[Authorize]
public class DashboardController : Controller
{
    public IActionResult Subscription() { return View(); }
    public IActionResult MyContestEntries() { return View(); }
    public IActionResult MyRecipes() { return View(); }
    public IActionResult MyTips() { return View(); }
    public IActionResult AddRecipe() { return View(); }
    public IActionResult ProfileSettings() { return View(); }
    public IActionResult AddTip() { return View(); }
    public IActionResult Index() { return View(); }
}
