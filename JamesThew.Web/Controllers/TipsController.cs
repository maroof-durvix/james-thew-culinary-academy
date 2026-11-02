using JamesThew.Web.Data;
using JamesThew.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JamesThew.Web.Controllers
{
    public class TipsController : Controller
    {
        private readonly JamesThewDbContext _context;
        private readonly ILogger<TipsController> _logger;

        public TipsController(JamesThewDbContext context, ILogger<TipsController> logger)
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
            ViewData["Title"] = "Free Culinary Tips & Tricks - Chef James Thew";

            var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = category;
            ViewBag.SearchTerm = search;

            var query = _context.Tips
                .Include(t => t.Category)
                .Include(t => t.Author)
                .Where(t => t.Access == "Free");

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                query = query.Where(t => t.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchLower = search.Trim().ToLower();
                query = query.Where(t => t.Title.ToLower().Contains(searchLower)
                    || t.Description.ToLower().Contains(searchLower));
            }

            var tips = await query.OrderByDescending(t => t.CreatedAt).ToListAsync();
            return View(tips);
        }

        [HttpGet]
        public async Task<IActionResult> Premium(string? category, string? search)
        {
            ViewData["Title"] = "Premium Chef Secrets & Master Techniques - James Thew VIP";

            var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();
            ViewBag.Categories = categories;
            ViewBag.SelectedCategory = category;
            ViewBag.SearchTerm = search;

            bool isMember = User.Identity != null && User.Identity.IsAuthenticated &&
                (User.IsInRole("Member") || User.IsInRole("Admin"));
            ViewBag.IsMember = isMember;

            var query = _context.Tips
                .Include(t => t.Category)
                .Include(t => t.Author)
                .Where(t => t.Access == "Premium");

            if (!string.IsNullOrWhiteSpace(category) && category != "All")
            {
                query = query.Where(t => t.Category.Name == category);
            }

            if (!string.IsNullOrWhiteSpace(search))
            {
                var searchLower = search.Trim().ToLower();
                query = query.Where(t => t.Title.ToLower().Contains(searchLower)
                    || t.Description.ToLower().Contains(searchLower));
            }

            var tips = await query.OrderByDescending(t => t.CreatedAt).ToListAsync();
            return View(tips);
        }

        [HttpGet]
        public async Task<IActionResult> Details(int? id)
        {
            if (!id.HasValue)
            {
                return RedirectToAction(nameof(Free));
            }

            var tip = await _context.Tips
                .Include(t => t.Category)
                .Include(t => t.Author)
                .FirstOrDefaultAsync(t => t.Id == id.Value);

            if (tip == null)
            {
                return NotFound();
            }

            // Free / unauthenticated / non-member users cannot view Premium details directly; redirect to Register
            if (tip.Access == "Premium" && (User.Identity == null || !User.Identity.IsAuthenticated || (!User.IsInRole("Member") && !User.IsInRole("Admin"))))
            {
                return RedirectToAction("Register", "Auth");
            }

            bool isMember = User.Identity != null && User.Identity.IsAuthenticated &&
                (User.IsInRole("Member") || User.IsInRole("Admin"));
            ViewBag.IsMember = isMember;

            var relatedTips = await _context.Tips
                .Include(t => t.Category)
                .Where(t => t.Id != tip.Id && (t.CategoryId == tip.CategoryId || t.Access == tip.Access))
                .OrderByDescending(t => t.CreatedAt)
                .Take(3)
                .ToListAsync();

            ViewBag.RelatedTips = relatedTips;
            ViewData["Title"] = $"{tip.Title} - Culinary Tip by Chef James Thew";

            return View(tip);
        }
    }
}
