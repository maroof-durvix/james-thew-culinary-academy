using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.Authentication.Cookies;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JamesThew.Web.Data;
using JamesThew.Web.Models.Entities;
using JamesThew.Web.Models.ViewModels;

namespace JamesThew.Web.Controllers
{
    [Authorize]
    public class DashboardController : Controller
    {
        private readonly JamesThewDbContext _context;
        private readonly IWebHostEnvironment _env;

        public DashboardController(JamesThewDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        private int? GetCurrentUserId()
        {
            var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(idClaim, out int id))
            {
                return id;
            }
            return null;
        }

        public async Task<IActionResult> Index()
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            var user = await _context.Users
                .Include(u => u.Subscriptions)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return RedirectToAction("Login", "Auth");

            var recipesCount = await _context.Recipes.CountAsync(r => r.AuthorId == userId);
            var tipsCount = await _context.Tips.CountAsync(t => t.AuthorId == userId);
            var entriesCount = await _context.ContestEntries.CountAsync(e => e.UserId == userId);

            var activeSub = user.Subscriptions
                .OrderByDescending(s => s.ExpiryDate)
                .FirstOrDefault(s => s.ExpiryDate > DateTime.UtcNow &&
                    (s.PaymentStatus == "Active" || s.PaymentStatus == "Paid" || s.PaymentStatus == "Success"));

            var recentRecipes = await _context.Recipes
                .Include(r => r.Category)
                .Where(r => r.AuthorId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .Take(5)
                .ToListAsync();

            var recentTips = await _context.Tips
                .Include(t => t.Category)
                .Where(t => t.AuthorId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .Take(5)
                .ToListAsync();

            var viewModel = new DashboardHomeViewModel
            {
                User = user,
                MyRecipesCount = recipesCount,
                MyTipsCount = tipsCount,
                MyEntriesCount = entriesCount,
                ActiveSubscription = activeSub,
                RecentRecipes = recentRecipes,
                RecentTips = recentTips
            };

            return View(viewModel);
        }

        public async Task<IActionResult> MyRecipes()
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            var recipes = await _context.Recipes
                .Include(r => r.Category)
                .Where(r => r.AuthorId == userId)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return View(recipes);
        }

        public IActionResult MyTips()
        {
            return RedirectToAction(nameof(Tips));
        }

        public async Task<IActionResult> Tips()
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            var tips = await _context.Tips
                .Include(t => t.Category)
                .Where(t => t.AuthorId == userId)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return View(tips);
        }

        public IActionResult MyContests()
        {
            return RedirectToAction(nameof(ContestEntries));
        }

        public IActionResult Favorites()
        {
            return RedirectToAction(nameof(MyRecipes));
        }

        public IActionResult MyEntries()
        {
            return RedirectToAction(nameof(ContestEntries));
        }

        public async Task<IActionResult> ContestEntries()
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            var entries = await _context.ContestEntries
                .Include(e => e.Contest)
                .Include(e => e.Category)
                .Where(e => e.UserId == userId)
                .OrderByDescending(e => e.SubmittedAt)
                .ToListAsync();

            return View(entries);
        }

        [HttpGet]
        public async Task<IActionResult> AddRecipe()
        {
            var model = new AddRecipeViewModel
            {
                AvailableCategories = await _context.Categories.OrderBy(c => c.Name).ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddRecipe(AddRecipeViewModel model)
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            if (!ModelState.IsValid)
            {
                model.AvailableCategories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
                return View(model);
            }

            string imagePath = "/images/recipe-default.jpg";
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var allowedExts = new[] { ".jpg", ".jpeg", ".png", ".webp" };
                var ext = Path.GetExtension(model.ImageFile.FileName).ToLowerInvariant();
                if (allowedExts.Contains(ext))
                {
                    var uploadsDir = Path.Combine(_env.WebRootPath, "uploads", "recipes");
                    Directory.CreateDirectory(uploadsDir);
                    var uniqueFileName = $"recipe_{Guid.NewGuid()}{ext}";
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                    imagePath = $"/uploads/recipes/{uniqueFileName}";
                }
            }

            var recipe = new Recipe
            {
                Title = model.Title.Trim(),
                CategoryId = model.CategoryId,
                Ingredients = model.Ingredients.Trim(),
                Procedure = model.Procedure.Trim(),
                PrepMinutes = model.PrepMinutes,
                CookMinutes = model.CookMinutes,
                Access = model.Access == "Premium" ? "Premium" : "Free",
                ImagePath = imagePath,
                AuthorId = userId.Value,
                CreatedAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow
            };

            _context.Recipes.Add(recipe);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Your recipe has been published to the culinary archive!";
            return RedirectToAction(nameof(MyRecipes));
        }

        [HttpGet]
        public async Task<IActionResult> AddTip()
        {
            var model = new AddTipViewModel
            {
                AvailableCategories = await _context.Categories.OrderBy(c => c.Name).ToListAsync()
            };
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddTip(AddTipViewModel model)
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            if (!ModelState.IsValid)
            {
                model.AvailableCategories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
                return View(model);
            }

            string imagePath = "/images/tip-default.jpg";
            if (model.ImageFile != null && model.ImageFile.Length > 0)
            {
                var allowedExts = new[] { ".jpg", ".jpeg", ".png", ".webp" };
                var ext = Path.GetExtension(model.ImageFile.FileName).ToLowerInvariant();
                if (allowedExts.Contains(ext))
                {
                    var uploadsDir = Path.Combine(_env.WebRootPath, "uploads", "tips");
                    Directory.CreateDirectory(uploadsDir);
                    var uniqueFileName = $"tip_{Guid.NewGuid()}{ext}";
                    var filePath = Path.Combine(uploadsDir, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.ImageFile.CopyToAsync(stream);
                    }
                    imagePath = $"/uploads/tips/{uniqueFileName}";
                }
            }

            var tip = new Tip
            {
                Title = model.Title.Trim(),
                CategoryId = model.CategoryId,
                Description = model.Description.Trim(),
                Access = model.Access == "Premium" ? "Premium" : "Free",
                ImagePath = imagePath,
                AuthorId = userId.Value,
                CreatedAt = DateTime.UtcNow
            };

            _context.Tips.Add(tip);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Your culinary technique tip has been published successfully!";
            return RedirectToAction(nameof(Tips));
        }

        public async Task<IActionResult> Subscription()
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            var user = await _context.Users
                .Include(u => u.Subscriptions)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return RedirectToAction("Login", "Auth");

            return View(user);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpgradePlan(string plan)
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            var user = await _context.Users.FindAsync(userId);
            if (user == null) return RedirectToAction("Login", "Auth");

            string planNormalized = plan == "Yearly" ? "Yearly" : "Monthly";
            decimal amount = planNormalized == "Yearly" ? 100.00m : 10.00m;
            DateTime expiry = planNormalized == "Yearly" ? DateTime.UtcNow.AddYears(1) : DateTime.UtcNow.AddMonths(1);

            var subscription = new Subscription
            {
                UserId = user.Id,
                Plan = $"{planNormalized} Mastership",
                Amount = amount,
                StartDate = DateTime.UtcNow,
                ExpiryDate = expiry,
                PaymentStatus = "Active",
                CreatedAt = DateTime.UtcNow
            };

            _context.Subscriptions.Add(subscription);
            
            // Upgrade role if user was free
            if (user.Role == "Free")
            {
                user.Role = "Member";
            }
            await _context.SaveChangesAsync();

            // Refresh cookie authentication claims so role takes immediate effect
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("AvatarPath", !string.IsNullOrEmpty(user.AvatarPath) ? user.AvatarPath : "/images/default-avatar.png")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            TempData["Success"] = $"Your {planNormalized} subscription has been activated successfully! Welcome to The Sanctuary Member Tier.";
            return RedirectToAction(nameof(Subscription));
        }

        public async Task<IActionResult> Profile()
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            var user = await _context.Users
                .Include(u => u.Subscriptions)
                .FirstOrDefaultAsync(u => u.Id == userId);

            if (user == null) return RedirectToAction("Login", "Auth");

            var activeSub = user.Subscriptions
                .OrderByDescending(s => s.ExpiryDate)
                .FirstOrDefault(s => s.ExpiryDate > DateTime.UtcNow &&
                    (s.PaymentStatus == "Active" || s.PaymentStatus == "Paid" || s.PaymentStatus == "Success"));

            var model = new ProfileViewModel
            {
                FullName = user.FullName,
                Email = user.Email,
                Phone = user.Phone ?? string.Empty,
                AvatarPath = user.AvatarPath,
                Role = user.Role,
                ActiveSubscription = activeSub
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> UpdateProfile(ProfileViewModel model)
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            var user = await _context.Users.FindAsync(userId);
            if (user == null) return RedirectToAction("Login", "Auth");

            if (string.IsNullOrWhiteSpace(model.FullName) || !System.Text.RegularExpressions.Regex.IsMatch(model.FullName.Trim(), @"^[a-zA-Z\s]{2,50}$"))
            {
                TempData["Error"] = "Full Name must contain only letters and spaces (2 to 50 characters).";
                return RedirectToAction(nameof(Profile));
            }

            if (!string.IsNullOrWhiteSpace(model.Phone))
            {
                var digits = System.Text.RegularExpressions.Regex.Replace(model.Phone, @"[^\d]", "");
                if (!System.Text.RegularExpressions.Regex.IsMatch(model.Phone.Trim(), @"^[\+]?[0-9\s\-]{7,16}$") || digits.Length < 7 || digits.Length > 15)
                {
                    TempData["Error"] = "Please enter a valid phone number (7 to 15 digits).";
                    return RedirectToAction(nameof(Profile));
                }
            }

            user.FullName = model.FullName.Trim();
            user.Phone = model.Phone?.Trim() ?? string.Empty;

            if (model.AvatarFile != null && model.AvatarFile.Length > 0)
            {
                var allowedExts = new[] { ".jpg", ".jpeg", ".png", ".webp" };
                var ext = Path.GetExtension(model.AvatarFile.FileName).ToLowerInvariant();
                if (allowedExts.Contains(ext))
                {
                    var avatarsDir = Path.Combine(_env.WebRootPath, "uploads", "avatars");
                    Directory.CreateDirectory(avatarsDir);
                    var uniqueFileName = $"avatar_{user.Id}_{Guid.NewGuid()}{ext}";
                    var filePath = Path.Combine(avatarsDir, uniqueFileName);
                    using (var stream = new FileStream(filePath, FileMode.Create))
                    {
                        await model.AvatarFile.CopyToAsync(stream);
                    }
                    user.AvatarPath = $"/uploads/avatars/{uniqueFileName}";
                }
            }

            await _context.SaveChangesAsync();

            // Refresh cookie authentication claims
            var claims = new List<Claim>
            {
                new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()),
                new Claim(ClaimTypes.Name, user.FullName),
                new Claim(ClaimTypes.Email, user.Email),
                new Claim(ClaimTypes.Role, user.Role),
                new Claim("AvatarPath", !string.IsNullOrEmpty(user.AvatarPath) ? user.AvatarPath : "/images/default-avatar.png")
            };
            var identity = new ClaimsIdentity(claims, CookieAuthenticationDefaults.AuthenticationScheme);
            await HttpContext.SignInAsync(CookieAuthenticationDefaults.AuthenticationScheme, new ClaimsPrincipal(identity));

            TempData["Success"] = "Your profile information has been updated successfully.";
            return RedirectToAction(nameof(Profile));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ChangePassword(ProfileViewModel model)
        {
            var userId = GetCurrentUserId();
            if (userId == null) return RedirectToAction("Login", "Auth");

            var user = await _context.Users.FindAsync(userId);
            if (user == null) return RedirectToAction("Login", "Auth");

            if (string.IsNullOrEmpty(model.CurrentPassword) || string.IsNullOrEmpty(model.NewPassword))
            {
                TempData["Error"] = "Both current password and new password are required.";
                return RedirectToAction(nameof(Profile));
            }

            if (model.NewPassword.Length < 6)
            {
                TempData["Error"] = "New password must be at least 6 characters long.";
                return RedirectToAction(nameof(Profile));
            }

            if (model.NewPassword != model.ConfirmPassword)
            {
                TempData["Error"] = "New password and confirmation do not match.";
                return RedirectToAction(nameof(Profile));
            }

            bool isCurrentValid = false;
            if (user.PasswordHash.StartsWith("$2a$") || user.PasswordHash.StartsWith("$2b$") || user.PasswordHash.StartsWith("$2y$"))
            {
                try
                {
                    isCurrentValid = BCrypt.Net.BCrypt.Verify(model.CurrentPassword, user.PasswordHash);
                }
                catch
                {
                    isCurrentValid = false;
                }
            }
            else
            {
                isCurrentValid = (user.PasswordHash == model.CurrentPassword);
            }

            if (!isCurrentValid)
            {
                TempData["Error"] = "Incorrect current password. Please try again.";
                return RedirectToAction(nameof(Profile));
            }

            user.PasswordHash = BCrypt.Net.BCrypt.HashPassword(model.NewPassword);
            await _context.SaveChangesAsync();

            TempData["Success"] = "Password updated successfully.";
            return RedirectToAction(nameof(Profile));
        }
    }
}
