using Microsoft.AspNetCore.Mvc;

namespace JamesThew.Web.Controllers
{
    public class AccountController : Controller
    {
        public IActionResult Login(string? returnUrl = null)
        {
            return RedirectToAction("Login", "Auth", new { returnUrl });
        }

        public IActionResult Register()
        {
            return RedirectToAction("Register", "Auth");
        }

        public IActionResult ForgotPassword()
        {
            return RedirectToAction("ForgotPassword", "Auth");
        }

        public IActionResult ResetPassword(string? token = null)
        {
            return RedirectToAction("ResetPassword", "Auth", new { token });
        }

        public IActionResult Logout()
        {
            return RedirectToAction("Logout", "Auth");
        }
    }
}
