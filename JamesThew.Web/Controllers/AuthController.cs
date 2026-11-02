using System.Security.Claims;
using JamesThew.Web.Data;
using JamesThew.Web.Models.Entities;
using JamesThew.Web.ViewModels;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JamesThew.Web.Controllers
{
    public class AuthController : Controller
    {
        private readonly JamesThewDbContext _context;
        private readonly ILogger<AuthController> _logger;

        public AuthController(JamesThewDbContext context, ILogger<AuthController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Login(string? returnUrl = null, bool expired = false)
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                if (User.IsInRole("Admin"))
                    return RedirectToAction("Index", "Admin");
                return RedirectToAction("Index", "Dashboard");
            }

            if (expired)
            {
                ViewData["ExpiredMessage"] = "Your membership plan has expired. You have been automatically logged out. Please recharge your plan to continue accessing JamesThew VIP features.";
            }

            ViewData["ReturnUrl"] = returnUrl;
            ViewData["Title"] = "Login";
            return View(new LoginViewModel { ReturnUrl = returnUrl });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Login(LoginViewModel model, string? returnUrl = null)
        {
            ViewData["Title"] = "Login";
            ViewData["ReturnUrl"] = returnUrl ?? model.ReturnUrl;

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var emailLower = model.Email.Trim().ToLower();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == emailLower);

            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid email address or password.");
                return View(model);
            }

            bool isPasswordValid = false;
            if (user.PasswordHash.StartsWith("$2a$") || user.PasswordHash.StartsWith("$2b$") || user.PasswordHash.StartsWith("$2y$"))
            {
                try
                {
                    isPasswordValid = BCrypt.Net.BCrypt.Verify(model.Password, user.PasswordHash);
                }
                catch
                {
                    isPasswordValid = false;
                }
            }
            else
            {
                // Fallback for seed plain text passwords
                isPasswordValid = (user.PasswordHash == model.Password);
                if (isPasswordValid)
                {
                    user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password);
                    await _context.SaveChangesAsync();
                }
            }

            if (!isPasswordValid)
            {
                ModelState.AddModelError(string.Empty, "Invalid email address or password.");
                return View(model);
            }

            if (user.IsBlocked)
            {
                ModelState.AddModelError(string.Empty, "Your account has been deactivated. Please contact support.");
                return View(model);
            }

            // Verify active subscription for Member role: expired members cannot log in until recharged
            if (user.Role == "Member")
            {
                var now = DateTime.UtcNow;
                var hasActiveSub = await _context.Subscriptions.AnyAsync(s =>
                    s.UserId == user.Id &&
                    s.ExpiryDate > now &&
                    s.PaymentStatus != "Failed" &&
                    s.PaymentStatus != "Cancelled" &&
                    s.PaymentStatus != "Refunded");

                if (!hasActiveSub)
                {
                    ModelState.AddModelError(string.Empty, "Your paid membership plan has expired. Please recharge or renew your plan to log in.");
                    ViewData["IsExpiredMember"] = true;
                    ViewData["ExpiredEmail"] = user.Email;
                    return View(model);
                }
            }

            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("AvatarPath", !string.IsNullOrEmpty(user.AvatarPath) ? user.AvatarPath : "/images/default-avatar.png")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            var authProperties = new AuthenticationProperties
            {
                IsPersistent = model.RememberMe,
                ExpiresUtc = DateTimeOffset.UtcNow.AddDays(model.RememberMe ? 14 : 1)
            };

            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                authProperties);

            _logger.LogInformation("User {Email} logged in successfully.", user.Email);

            var targetUrl = returnUrl ?? model.ReturnUrl;
            if (!string.IsNullOrEmpty(targetUrl) && Url.IsLocalUrl(targetUrl))
            {
                return Redirect(targetUrl);
            }

            if (user.Role == "Admin")
            {
                return RedirectToAction("Index", "Admin");
            }

            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult Register()
        {
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                return RedirectToAction("Index", "Dashboard");
            }

            ViewData["Title"] = "Register";
            return View(new RegisterViewModel());
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Register(RegisterViewModel model)
        {
            ViewData["Title"] = "Register";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(model.FullName.Trim(), @"^[a-zA-Z\s]{2,50}$"))
            {
                ModelState.AddModelError("FullName", "Full Name must contain only letters and spaces (2 to 50 characters).");
                return View(model);
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(model.Email.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                ModelState.AddModelError("Email", "Please enter a valid email address (e.g. name@domain.com).");
                return View(model);
            }

            if (!string.IsNullOrWhiteSpace(model.Phone))
            {
                var digits = System.Text.RegularExpressions.Regex.Replace(model.Phone, @"[^\d]", "");
                if (!System.Text.RegularExpressions.Regex.IsMatch(model.Phone.Trim(), @"^[\+]?[0-9\s\-]{7,16}$") || digits.Length < 7 || digits.Length > 15)
                {
                    ModelState.AddModelError("Phone", "Please enter a valid phone number (7 to 15 digits).");
                    return View(model);
                }
            }

            var emailLower = model.Email.Trim().ToLower();
            if (await _context.Users.AnyAsync(u => u.Email.ToLower() == emailLower))
            {
                ModelState.AddModelError("Email", "An account with this email address already exists.");
                return View(model);
            }

            string role = "Member";
            decimal amount = 0m;
            int durationMonths = 0;
            var chosenPlan = model.Plan?.Trim() ?? "Free";

            if (chosenPlan.Equals("Monthly", StringComparison.OrdinalIgnoreCase))
            {
                amount = 10.00m;
                durationMonths = 1;
            }
            else if (chosenPlan.Equals("Yearly", StringComparison.OrdinalIgnoreCase))
            {
                amount = 100.00m;
                durationMonths = 12;
            }
            else
            {
                // Free plan not allowed - redirect to plans page
                TempData["InfoMessage"] = "Please select a paid membership plan to join JamesThew.com.";
                return RedirectToAction("Index", "Plans");
            }

            var user = new User
            {
                FullName = model.FullName.Trim(),
                Email = emailLower,
                Phone = model.Phone?.Trim() ?? string.Empty,
                PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.Password),
                Role = role,
                AvatarPath = string.Empty,
                IsBlocked = false,
                CreatedAt = DateTime.UtcNow
            };

            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            if (role == "Member")
            {
                var subscription = new Subscription
                {
                    UserId = user.Id,
                    Plan = chosenPlan,
                    Amount = amount,
                    StartDate = DateTime.UtcNow,
                    ExpiryDate = DateTime.UtcNow.AddMonths(durationMonths),
                    PaymentStatus = "Success",
                    CreatedAt = DateTime.UtcNow
                };
                _context.Subscriptions.Add(subscription);
                await _context.SaveChangesAsync();
            }

            // Auto-sign in user
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("AvatarPath", "/images/default-avatar.png")
            };

            var claimsIdentity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(
                CookieAuthenticationDefaults.AuthenticationScheme,
                new ClaimsPrincipal(claimsIdentity),
                new AuthenticationProperties { IsPersistent = true, ExpiresUtc = DateTimeOffset.UtcNow.AddDays(14) });

            TempData["SuccessMessage"] = $"Welcome to JamesThew.com, {user.FullName}!";
            return RedirectToAction("Index", "Dashboard");
        }

        [HttpGet]
        public IActionResult ForgotPassword()
        {
            ViewData["Title"] = "Forgot Password";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ForgotPassword(string email)
        {
            ViewData["Title"] = "Forgot Password";

            if (string.IsNullOrWhiteSpace(email))
            {
                TempData["ErrorMessage"] = "Please provide a valid email address.";
                return View();
            }

            var emailLower = email.Trim().ToLower();
            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == emailLower);

            if (user != null)
            {
                var token = Guid.NewGuid().ToString("N");
                var resetToken = new PasswordResetToken
                {
                    UserId = user.Id,
                    TokenHash = token,
                    ExpiresAt = DateTime.UtcNow.AddMinutes(30),
                    UsedAt = null
                };
                _context.PasswordResetTokens.Add(resetToken);
                await _context.SaveChangesAsync();

                TempData["SuccessMessage"] = $"A password reset link has been dispatched to {email}. (Security Token: {token})";
            }
            else
            {
                // Prevent user enumeration
                TempData["SuccessMessage"] = $"If an account exists for {email}, instructions have been dispatched.";
            }

            return View();
        }

        [HttpGet]
        public IActionResult ResetPassword(string? token, string? email)
        {
            ViewData["Title"] = "Reset Password";
            return View(new ResetPasswordViewModel
            {
                Token = token ?? string.Empty,
                Email = email ?? string.Empty
            });
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ResetPassword(ResetPasswordViewModel model)
        {
            ViewData["Title"] = "Reset Password";

            if (!ModelState.IsValid)
            {
                return View(model);
            }

            var user = await _context.Users.FirstOrDefaultAsync(u => u.Email.ToLower() == model.Email.Trim().ToLower());
            if (user == null)
            {
                ModelState.AddModelError(string.Empty, "Invalid password reset request.");
                return View(model);
            }

            var tokenRecord = await _context.PasswordResetTokens
                .Where(t => t.UserId == user.Id && t.TokenHash == model.Token && t.UsedAt == null && t.ExpiresAt > DateTime.UtcNow)
                .OrderByDescending(t => t.ExpiresAt)
                .FirstOrDefaultAsync();

            if (tokenRecord == null)
            {
                ModelState.AddModelError(string.Empty, "This password reset token is invalid or has expired.");
                return View(model);
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            tokenRecord.UsedAt = DateTime.UtcNow;
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Your password has been reset successfully. You can now login.";
            return RedirectToAction("Login");
        }

        public async Task<IActionResult> Logout()
        {
            await HttpContext.SignOutAsync(CookieAuthenticationDefaults.AuthenticationScheme);
            return RedirectToAction("Index", "Home");
        }

        public IActionResult AccessDenied()
        {
            ViewData["Title"] = "Access Denied";
            return View();
        }
    }
}
