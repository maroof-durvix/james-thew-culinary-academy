using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers;

public class ErrorController : Controller
{
    [Route("Error/{statusCode}")]
    public IActionResult HttpStatusCodeHandler(int statusCode)
    {
        switch (statusCode)
        {
            case 404:
                ViewBag.ErrorMessage = "Sorry, the resource you requested could not be found.";
                break;
            case 403:
                ViewBag.ErrorMessage = "Sorry, you are not authorized to view this page.";
                break;
            case 500:
                ViewBag.ErrorMessage = "Sorry, something went wrong on our end.";
                break;
            default:
                ViewBag.ErrorMessage = "Sorry, an error occurred.";
                break;
        }
        return View("NotFound");
    }
}
