using JamesThew.Web.Data;
using JamesThew.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace JamesThew.Web.Controllers
{
    public class RecipesController : Controller
    {
        private readonly JamesThewDbContext _context;
        private readonly ILogger<RecipesController> _logger;

        public RecipesController(JamesThewDbContext context, ILogger<RecipesController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Free));
        }

        [HttpGet]
        public async Task<IActionResult> Free(string? category, string? search)
        {
            ViewData["Title"] = "Free Recipes - Chef James Thew";

            var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = category;
            ViewBag.SearchTerm = search;

            var query = _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Author)
                .Include(r => r.Feedbacks)
                .Where(r => r.Access == "Free");

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                query = query.Where(r => r.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchLower = search.Trim().ToLower();
                query = query.Where(r => r.Title.ToLower().Contains(searchLower)
                    || r.Ingredients.ToLower().Contains(searchLower)
                    || r.Procedure.ToLower().Contains(searchLower));
            }

            var recipes = await query.OrderByDescending(r => r.CreatedAt).ToListAsync();
            return View(recipes);
        }

        [HttpGet]
        public async Task<IActionResult> Premium(string? category, string? search)
        {
            ViewData["Title"] = "Premium Master Recipes - James Thew VIP";

            var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = category;
            ViewBag.SearchTerm = search;

            bool isMember = User.Identity != null && User.Identity.IsAuthenticated && 
                (User.IsInRole("Member") || User.IsInRole("Admin"));
            ViewBag.IsMember = isMember;

            var query = _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Author)
                .Include(r => r.Feedbacks)
                .Where(r => r.Access == "Premium");

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                query = query.Where(r => r.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchLower = search.Trim().ToLower();
                query = query.Where(r => r.Title.ToLower().Contains(searchLower)
                    || r.Ingredients.ToLower().Contains(searchLower)
                    || r.Procedure.ToLower().Contains(searchLower));
            }

            var recipes = await query.OrderByDescending(r => r.CreatedAt).ToListAsync();
            return View(recipes);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(Free));
            }

            var recipe = await _context.Recipes
                .Include(r => r.Category)
                .Include(r => r.Author)
                .Include(r => r.Feedbacks)
                    .ThenInclude(f => f.User)
                .FirstOrDefaultAsync(r => r.Id == id.Value);

            if (recipe == null)
            {
                return NotFound();
            }

            // Free / unauthenticated / non-member users cannot view Premium details directly; redirect to Register
            if (recipe.Access == "Premium" && (User.Identity == null || !User.Identity.IsAuthenticated || (!User.IsInRole("Member") && !User.IsInRole("Admin"))))
            {
                return RedirectToAction("Register", "Auth");
            }

            bool isMember = User.Identity != null && User.Identity.IsAuthenticated && 
                (User.IsInRole("Member") || User.IsInRole("Admin"));
            ViewBag.IsMember = isMember;

            // Related recipes from same category or general
            var related = await _context.Recipes
                .Include(r => r.Category)
                .Where(r => r.Id != recipe.Id && (r.CategoryId == recipe.CategoryId || r.Access == recipe.Access))
                .OrderByDescending(r => r.CreatedAt)
                .Take(3)
                .ToListAsync();

            ViewBag.RelatedRecipes = related;
            ViewData["Title"] = $"{recipe.Title} - Recipe by Chef James Thew";

            return View(recipe);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> AddFeedback(int recipeId, string userName, string userEmail, int rating, string comment)
        {
            var recipe = await _context.Recipes.FindAsync(recipeId);
            if (recipe == null)
            {
                return NotFound();
            }

            if (string.IsNullOrWhiteSpace(comment))
            {
                TempData["ErrorMessage"] = "Feedback comment cannot be empty.";
                return RedirectToAction(nameof(Details), new { id = recipeId });
            }

            if (!string.IsNullOrWhiteSpace(userName))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(userName.Trim(), @"^[a-zA-Z\s]{2,50}$"))
                {
                    TempData["ErrorMessage"] = "Please enter a valid name (letters and spaces only, 2 to 50 characters).";
                    return RedirectToAction(nameof(Details), new { id = recipeId });
                }
            }

            if (!string.IsNullOrWhiteSpace(userEmail))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(userEmail.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    TempData["ErrorMessage"] = "Please enter a valid email address (e.g. name@domain.com).";
                    return RedirectToAction(nameof(Details), new { id = recipeId });
                }
            }

            if (comment.Trim().Length < 5)
            {
                TempData["ErrorMessage"] = "Feedback comment must be at least 5 characters.";
                return RedirectToAction(nameof(Details), new { id = recipeId });
            }

            int? currentUserId = null;
            if (User.Identity != null && User.Identity.IsAuthenticated)
            {
                var idClaim = User.FindFirstValue(ClaimTypes.NameIdentifier);
                if (int.TryParse(idClaim, out int uid))
                {
                    currentUserId = uid;
                }
            }

            var feedback = new RecipeFeedback
            {
                RecipeId = recipeId,
                UserId = currentUserId,
                Name = !string.IsNullOrWhiteSpace(userName) ? userName.Trim() : (User.Identity?.Name ?? "Gourmet Visitor"),
                Email = !string.IsNullOrWhiteSpace(userEmail) ? userEmail.Trim().ToLower() : (User.FindFirstValue(ClaimTypes.Email) ?? "guest@jamesthew.com"),
                Rating = (rating >= 1 && rating <= 5) ? rating : 5,
                Comment = comment.Trim(),
                CreatedAt = DateTime.UtcNow
            };

            _context.RecipeFeedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Your review and culinary notes have been posted successfully!";
            return RedirectToAction(nameof(Details), new { id = recipeId });
        }
    }
}
