using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

public class FeedbackController : Controller
{
    public IActionResult SiteFeedback()
    {
        return View();
    }

}
