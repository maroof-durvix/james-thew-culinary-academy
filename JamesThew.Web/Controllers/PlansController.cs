using JamesThew.Web.Data;
using JamesThew.Web.Models.Entities;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace JamesThew.Web.Controllers
{
    public class PlansController : Controller
    {
        private readonly JamesThewDbContext _context;
        private readonly ILogger<PlansController> _logger;

        public PlansController(JamesThewDbContext context, ILogger<PlansController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            ViewData["Title"] = "Membership Plans - Haute Gastronomy Guild";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Subscribe(string plan)
        {
            if (User.Identity == null || !User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Register", "Auth", new { returnUrl = Url.Action("Index", "Plans") });
            }

            var userIdClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (!int.TryParse(userIdClaim, out int userId))
            {
                return RedirectToAction("Login", "Auth");
            }

            var user = await _context.Users.FindAsync(userId);
            if (user == null)
            {
                return RedirectToAction("Login", "Auth");
            }

            var selectedPlan = plan?.Equals("Yearly", StringComparison.OrdinalIgnoreCase) == true ? "Yearly" : "Monthly";
            var amount = selectedPlan == "Yearly" ? 100.00m : 10.00m;
            var now = DateTime.UtcNow;
            var expiry = selectedPlan == "Yearly" ? now.AddYears(1) : now.AddMonths(1);

            var subscription = new Subscription
            {
                UserId = user.Id,
                Plan = selectedPlan,
                Amount = amount,
                StartDate = now,
                ExpiryDate = expiry,
                PaymentStatus = "Paid",
                CreatedAt = now
            };

            _context.Subscriptions.Add(subscription);

            if (user.Role != "Admin")
            {
                user.Role = "Member";
            }
            await _context.SaveChangesAsync();

            // Refresh cookie authentication claims ticket
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("AvatarPath", user.AvatarPath ?? "")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            TempData["SuccessMessage"] = $"Congratulations! You have successfully upgraded to the {selectedPlan} Master Pass.";
            return RedirectToAction("Subscription", "Dashboard");
        }

        [HttpGet]
        public IActionResult Recharge(string? email = null)
        {
            ViewData["Title"] = "Recharge Membership - Haute Gastronomy Guild";
            ViewBag.PreFillEmail = email ?? "";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Recharge(string email, string password, string plan, string? cardNumber = null)
        {
            ViewData["Title"] = "Recharge Membership - Haute Gastronomy Guild";
            ViewBag.PreFillEmail = email;

            if (string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(password))
            {
                ModelState.AddModelError(string.Empty, "Email and password are required to recharge your plan.");
                return View();
            }

            var emailLower = email.Trim().ToLower();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == emailLower);
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "No account found with this email address.");
                return View();
            }

            bool isPasswordValid = false;
            if (user.PasswordHash.StartsWith("$2a$") || user.PasswordHash.StartsWith("$2b$") || user.PasswordHash.StartsWith("$2y$"))
            {
                try
                {
                    isPasswordValid = BCrypt.Net.BCrypt.Verify(password, user.PasswordHash);
                }
                catch
                {
                    isPasswordValid = false;
                }
            }
            else
            {
                isPasswordValid = (user.PasswordHash == password);
            }

            if (!isPasswordValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid password for this account.");
                return View();
            }

            var selectedPlan = plan?.Equals("Yearly", StringComparison.OrdinalIgnoreCase) == true ? "Yearly" : "Monthly";
            var amount = selectedPlan == "Yearly" ? 100.00m : 10.00m;
            var now = DateTime.UtcNow;
            var expiry = selectedPlan == "Yearly" ? now.AddYears(1) : now.AddMonths(1);

            var subscription = new Subscription
            {
                UserId = user.Id,
                Plan = selectedPlan,
                Amount = amount,
                StartDate = now,
                ExpiryDate = expiry,
                PaymentStatus = "Active",
                CreatedAt = now
            };

            _context.Subscriptions.Add(subscription);

            if (user.Role != "Admin")
            {
                user.Role = "Member";
            }
            user.IsBlocked = false;

            await _context.SaveChangesAsync();

            // Automatically sign in upon successful recharge
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("AvatarPath", !string.IsNullOrEmpty(user.AvatarPath) ? user.AvatarPath : "/images/default-avatar.png")
            };

            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity), new AuthenticationProperties
            {
                IsPersistent = true,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(14)
            });

            TempData["SuccessMessage"] = $"Your {selectedPlan} VIP membership has been successfully recharged! Welcome back.";
            return RedirectToAction("Index", "Dashboard");
        }
    }
}
