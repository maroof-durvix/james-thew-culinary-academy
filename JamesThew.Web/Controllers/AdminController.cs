using System;
using System.IO;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using System.Collections.Generic;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JamesThew.Web.Data;
using JamesThew.Web.Models.Entities;
using JamesThew.Web.Models.ViewModels;

namespace JamesThew.Web.Controllers
{
    [Authorize(Roles = "Admin")]
    public class AdminController : Controller
    {
        private readonly JamesThewDbContext _context;
        private readonly IWebHostEnvironment _env;

        public AdminController(JamesThewDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        private int GetAdminUserId()
        {
            var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
            if (int.TryParse(idClaim, out int id))
            {
                return id;
            }
            return 1;
        }

        public async Task<IActionResult> Index()
        {
            var totalRecipes = await _context.Recipes.CountAsync();
            var totalTips = await _context.Tips.CountAsync();
            var totalUsers = await _context.Users.CountAsync();
            var totalMembers = await _context.Users.CountAsync(u => u.Role == "Member");
            var totalContests = await _context.Contests.CountAsync();
            var totalContestEntries = await _context.ContestEntries.CountAsync();
            var totalFeedbacks = await _context.ContactMessages.CountAsync() + await _context.SiteFeedbacks.CountAsync();

            var recentRecipes = await _context.Recipes
                .Include(r => r.Category)
                .OrderByDescending(r => r.CreatedAt)
                .Take(5)
                .ToListAsync();

            var recentEntries = await _context.ContestEntries
                .Include(e => e.Contest)
                .OrderByDescending(e => e.SubmittedAt)
                .Take(5)
                .ToListAsync();

            var recentUsers = await _context.Users
                .OrderByDescending(u => u.CreatedAt)
                .Take(5)
                .ToListAsync();

            var model = new AdminDashboardViewModel
            {
                TotalRecipes = totalRecipes,
                TotalTips = totalTips,
                TotalUsers = totalUsers,
                TotalMembers = totalMembers,
                TotalContests = totalContests,
                TotalContestEntries = totalContestEntries,
                TotalFeedbacks = totalFeedbacks,
                RecentRecipes = recentRecipes,
                RecentEntries = recentEntries,
                RecentUsers = recentUsers
            };

            return View(model);
        }

        public async Task<IActionResult> Users()
        {
            var users = await _context.Users
                .Include(u => u.Subscriptions)
                .OrderByDescending(u => u.CreatedAt)
                .ToListAsync();

            return View(users);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleBlockUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            if (user != null)
            {
                if (user.Role == "Admin")
                {
                    TempData["Error"] = "Cannot deactivate an Administrator account.";
                }
                else
                {
                    user.IsBlocked = !user.IsBlocked;
                    await _context.SaveChangesAsync();
                    TempData["Success"] = user.IsBlocked 
                        ? $"User {user.FullName} has been deactivated." 
                        : $"User {user.FullName} has been reactivated.";
                }
            }
            return RedirectToAction(nameof(Users));
        }

        public async Task<IActionResult> Recipes()
        {
            var recipes = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Author)
                .OrderByDescending(r => r.CreatedAt)
                .ToListAsync();

            return View(recipes);
        }

        [HttpGet("Admin/Recipes/Create")]
        public IActionResult CreateRecipeAlias() => RedirectToAction(nameof(RecipeForm));

        [HttpGet("Admin/Tips/Create")]
        public IActionResult CreateTipAlias() => RedirectToAction(nameof(TipForm));

        [HttpGet("Admin/Announcements/Create")]
        public IActionResult CreateAnnouncementAlias() => RedirectToAction(nameof(Announcements));

        [HttpGet]
        public async Task<IActionResult> RecipeForm(int? id)
        {
            var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();

            if (id.HasValue && id.Value > 0)
            {
                var recipe = await _context.Recipes.FindAsync(id.Value);
                if (recipe == null) return NotFound();

                var editModel = new AdminRecipeFormViewModel
                {
                    Id = recipe.Id,
                    Title = recipe.Title,
                    CategoryId = recipe.CategoryId,
                    Ingredients = recipe.Ingredients,
                    Procedure = recipe.Procedure,
                    PrepMinutes = recipe.PrepMinutes,
                    CookMinutes = recipe.CookMinutes,
                    Access = recipe.Access,
                    CurrentImagePath = recipe.ImagePath,
                    Categories = categories
                };
                return View(editModel);
            }

            var newModel = new AdminRecipeFormViewModel
            {
                Categories = categories,
                Access = "Free"
            };
            return View(newModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> RecipeForm(AdminRecipeFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
                return View(model);
            }

            string imagePath = model.CurrentImagePath ?? "/images/recipe-default.jpg";
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

            if (model.Id > 0)
            {
                var existing = await _context.Recipes.FindAsync(model.Id);
                if (existing == null) return NotFound();

                existing.Title = model.Title.Trim();
                existing.CategoryId = model.CategoryId;
                existing.Ingredients = model.Ingredients.Trim();
                existing.Procedure = model.Procedure.Trim();
                existing.PrepMinutes = model.PrepMinutes;
                existing.CookMinutes = model.CookMinutes;
                existing.Access = model.Access == "Premium" ? "Premium" : "Free";
                existing.ImagePath = imagePath;
                existing.UpdatedAt = DateTime.UtcNow;

                await _context.SaveChangesAsync();
                TempData["Success"] = "Recipe updated successfully!";
            }
            else
            {
                var newRecipe = new Recipe
                {
                    Title = model.Title.Trim(),
                    CategoryId = model.CategoryId,
                    Ingredients = model.Ingredients.Trim(),
                    Procedure = model.Procedure.Trim(),
                    PrepMinutes = model.PrepMinutes,
                    CookMinutes = model.CookMinutes,
                    Access = model.Access == "Premium" ? "Premium" : "Free",
                    ImagePath = imagePath,
                    AuthorId = GetAdminUserId(),
                    CreatedAt = DateTime.UtcNow,
                    UpdatedAt = DateTime.UtcNow
                };

                _context.Recipes.Add(newRecipe);
                await _context.SaveChangesAsync();
                TempData["Success"] = "New recipe published successfully!";
            }

            return RedirectToAction(nameof(Recipes));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteRecipe(int id)
        {
            var recipe = await _context.Recipes.FindAsync(id);
            if (recipe != null)
            {
                _context.Recipes.Remove(recipe);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Recipe removed from culinary archive.";
            }
            return RedirectToAction(nameof(Recipes));
        }

        public async Task<IActionResult> Tips()
        {
            var tips = await _context.Tips
                .Include(t => t.Category)
                .Include(t => t.Author)
                .OrderByDescending(t => t.CreatedAt)
                .ToListAsync();

            return View(tips);
        }

        [HttpGet]
        public async Task<IActionResult> TipForm(int? id)
        {
            var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();

            if (id.HasValue && id.Value > 0)
            {
                var tip = await _context.Tips.FindAsync(id.Value);
                if (tip == null) return NotFound();

                var editModel = new AdminTipFormViewModel
                {
                    Id = tip.Id,
                    Title = tip.Title,
                    CategoryId = tip.CategoryId,
                    Description = tip.Description,
                    Access = tip.Access,
                    CurrentImagePath = tip.ImagePath,
                    Categories = categories
                };
                return View(editModel);
            }

            var newModel = new AdminTipFormViewModel
            {
                Categories = categories,
                Access = "Free"
            };
            return View(newModel);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> TipForm(AdminTipFormViewModel model)
        {
            if (!ModelState.IsValid)
            {
                model.Categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
                return View(model);
            }

            string imagePath = model.CurrentImagePath ?? "/images/tip-default.jpg";
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

            if (model.Id > 0)
            {
                var existing = await _context.Tips.FindAsync(model.Id);
                if (existing == null) return NotFound();

                existing.Title = model.Title.Trim();
                existing.CategoryId = model.CategoryId;
                existing.Description = model.Description.Trim();
                existing.Access = model.Access == "Premium" ? "Premium" : "Free";
                existing.ImagePath = imagePath;

                await _context.SaveChangesAsync();
                TempData["Success"] = "Culinary tip updated successfully!";
            }
            else
            {
                var newTip = new Tip
                {
                    Title = model.Title.Trim(),
                    CategoryId = model.CategoryId,
                    Description = model.Description.Trim(),
                    Access = model.Access == "Premium" ? "Premium" : "Free",
                    ImagePath = imagePath,
                    AuthorId = GetAdminUserId(),
                    CreatedAt = DateTime.UtcNow
                };

                _context.Tips.Add(newTip);
                await _context.SaveChangesAsync();
                TempData["Success"] = "New culinary technique tip published successfully!";
            }

            return RedirectToAction(nameof(Tips));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteTip(int id)
        {
            var tip = await _context.Tips.FindAsync(id);
            if (tip != null)
            {
                _context.Tips.Remove(tip);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Culinary tip removed.";
            }
            return RedirectToAction(nameof(Tips));
        }

        public async Task<IActionResult> Contests()
        {
            var contests = await _context.Contests
                .Include(c => c.Entries)
                .OrderByDescending(c => c.StartDate)
                .ToListAsync();

            return View(contests);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateContest(string title, string description, DateTime startDate, DateTime endDate)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(description))
            {
                TempData["Error"] = "Title and description are required for the contest.";
                return RedirectToAction(nameof(Contests));
            }

            var contest = new Contest
            {
                Title = title.Trim(),
                Description = description.Trim(),
                StartDate = startDate,
                EndDate = endDate,
                Status = DateTime.UtcNow < startDate ? "Upcoming" : (DateTime.UtcNow > endDate ? "Ended" : "Active"),
                CreatedAt = DateTime.UtcNow
            };

            _context.Contests.Add(contest);
            await _context.SaveChangesAsync();

            TempData["Success"] = $"Contest '{contest.Title}' created successfully!";
            return RedirectToAction(nameof(Contests));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContest(int id)
        {
            var contest = await _context.Contests.FindAsync(id);
            if (contest != null)
            {
                _context.Contests.Remove(contest);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Contest deleted.";
            }
            return RedirectToAction(nameof(Contests));
        }

        public async Task<IActionResult> ContestEntries()
        {
            var entries = await _context.ContestEntries
                .Include(e => e.Contest)
                .Include(e => e.User)
                .Include(e => e.Category)
                .OrderByDescending(e => e.SubmittedAt)
                .ToListAsync();

            return View(entries);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> SetEntryStatus(int id, string status)
        {
            var entry = await _context.ContestEntries
                .Include(e => e.Contest)
                .Include(e => e.User)
                .FirstOrDefaultAsync(e => e.Id == id);

            if (entry != null)
            {
                entry.Status = (status == "Winner") ? "Winner" : "Pending";
                
                if (entry.Status == "Winner")
                {
                    // Create winner announcement if not exists
                    var existingAnn = await _context.Announcements.FirstOrDefaultAsync(a => a.WinnerEntryId == entry.Id);
                    if (existingAnn == null)
                    {
                        var authorName = entry.User?.FullName ?? (!string.IsNullOrEmpty(entry.GuestName) ? entry.GuestName : "Talented Chef");
                        var contestTitle = entry.Contest?.Title ?? "Culinary Competition";
                        var ann = new Announcement
                        {
                            Type = "Winner",
                            Title = $"Winner Announced: {contestTitle}",
                            Message = $"Congratulations to {authorName} for claiming top honors with '{entry.Title}'!",
                            ContestId = entry.ContestId,
                            WinnerEntryId = entry.Id,
                            PostedAt = DateTime.UtcNow
                        };
                        _context.Announcements.Add(ann);
                    }
                }

                await _context.SaveChangesAsync();
                TempData["Success"] = $"Entry #{entry.Id} status marked as '{entry.Status}'.";
            }
            return RedirectToAction(nameof(ContestEntries));
        }

        public async Task<IActionResult> Announcements()
        {
            var announcements = await _context.Announcements
                .Include(a => a.Contest)
                .OrderByDescending(a => a.PostedAt)
                .ToListAsync();

            return View(announcements);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> CreateAnnouncement(string title, string message, string type)
        {
            if (string.IsNullOrWhiteSpace(title) || string.IsNullOrWhiteSpace(message))
            {
                TempData["Error"] = "Title and message are required.";
                return RedirectToAction(nameof(Announcements));
            }

            var ann = new Announcement
            {
                Title = title.Trim(),
                Message = message.Trim(),
                Type = string.IsNullOrWhiteSpace(type) ? "Update" : type.Trim(),
                PostedAt = DateTime.UtcNow
            };

            _context.Announcements.Add(ann);
            await _context.SaveChangesAsync();

            TempData["Success"] = "New platform announcement posted!";
            return RedirectToAction(nameof(Announcements));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteAnnouncement(int id)
        {
            var ann = await _context.Announcements.FindAsync(id);
            if (ann != null)
            {
                _context.Announcements.Remove(ann);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Announcement removed.";
            }
            return RedirectToAction(nameof(Announcements));
        }

        [HttpGet("Admin/Feedback")]
        public IActionResult FeedbackAlias() => RedirectToAction(nameof(Feedbacks));

        [HttpGet("Admin/ContactMessages")]
        public IActionResult ContactMessagesAlias() => RedirectToAction(nameof(Feedbacks));

        public async Task<IActionResult> Feedbacks()
        {
            var contactMessages = await _context.ContactMessages
                .OrderByDescending(m => m.CreatedAt)
                .ToListAsync();

            var siteFeedbacks = await _context.SiteFeedbacks
                .OrderByDescending(f => f.CreatedAt)
                .ToListAsync();

            return View((contactMessages, siteFeedbacks));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> ToggleShowOnHome(int id)
        {
            var feedback = await _context.SiteFeedbacks.FindAsync(id);
            if (feedback != null)
            {
                feedback.ShowOnHome = !feedback.ShowOnHome;
                await _context.SaveChangesAsync();
                TempData["Success"] = feedback.ShowOnHome ? "Feedback approved to display on Home page." : "Feedback hidden from Home page.";
            }
            return RedirectToAction(nameof(Feedbacks));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteFeedback(int id)
        {
            var feedback = await _context.SiteFeedbacks.FindAsync(id);
            if (feedback != null)
            {
                _context.SiteFeedbacks.Remove(feedback);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Feedback deleted.";
            }
            return RedirectToAction(nameof(Feedbacks));
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteContactMessage(int id)
        {
            var msg = await _context.ContactMessages.FindAsync(id);
            if (msg != null)
            {
                _context.ContactMessages.Remove(msg);
                await _context.SaveChangesAsync();
                TempData["Success"] = "Contact message deleted.";
            }
            return RedirectToAction(nameof(Feedbacks));
        }
    }
}
