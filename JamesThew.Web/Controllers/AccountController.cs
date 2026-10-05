using System;
using System.Collections.Generic;
using System.Security.Claims;
using System.Threading.Tasks;
using JamesThew.Web.Data;
using JamesThew.Web.Models.Entities;
using JamesThew.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JamesThew.Web.Controllers
{
    public class AccountController : Controller
    {
        private readonly JamesThewDbContext _context;
        private readonly PasswordHasher<User> _passwordHasher;

        public AccountController(JamesThewDbContext context)
        {
            _context = context;
            _passwordHasher = new PasswordHasher<User>();
        }

        [HttpGet]
        public IActionResult Login()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToDashboard();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                var user = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);

                if (user != null)
                {
                    var result = _passwordHasher.VerifyHashedPassword(user, user.PasswordHash, model.Password);
                    if (result == PasswordVerificationResult.Success || result == PasswordVerificationResult.SuccessRehashNeeded)
                    {
                        if (user.IsBlocked)
                        {
                            ModelState.AddModelError("", "Your account has been blocked.");
                            return View(model);
                        }

                        var claims = new List<Claim>
                        {
                            new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                            new Claim(ClaimTypes.Name, user.FullName),
                            new Claim(ClaimTypes.Email, user.Email),
                            new Claim(ClaimTypes.Role, user.Role),
                            new Claim("AvatarPath", user.AvatarPath ?? "")
                        };

                        var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                        var principal = new ClaimsPrincipal(identity);

                        await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                        return RedirectToDashboard();
                    }
                }

                ModelState.AddModelError("", "Invalid login attempt.");
            }

            return View(model);
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity?.IsAuthenticated == true)
            {
                return RedirectToDashboard();
            }
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                var existingUser = await _context.Users.FirstOrDefaultAsync(u => u.Email == model.Email);
                if (existingUser != null)
                {
                    ModelState.AddModelError("Email", "Email is already taken.");
                    return View(model);
                }

                var user = new User
                {
                    FullName = model.FullName,
                    Email = model.Email,
                    Role = "Free",
                    IsBlocked = false,
                    CreatedAt = DateTime.UtcNow
                };
                
                user.PasswordHash = _passwordHasher.HashPassword(user, model.Password);

                _context.Users.Add(user);
                await _context.SaveChangesAsync();

                var claims = new List<Claim>
                {
                    new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                    new Claim(ClaimTypes.Name, user.FullName),
                    new Claim(ClaimTypes.Email, user.Email),
                    new Claim(ClaimTypes.Role, user.Role),
                    new Claim("AvatarPath", "")
                };

                var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
                var principal = new ClaimsPrincipal(identity);

                await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, principal);

                return RedirectToDashboard();
            }

            return View(model);
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        private IActionResult RedirectToDashboard()
        {
            if (User.IsInRole("Admin"))
            {
                return RedirectToAction("Dashboard", "Admin");
            }
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
