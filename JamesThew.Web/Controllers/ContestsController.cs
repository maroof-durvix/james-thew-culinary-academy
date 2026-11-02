using JamesThew.Web.Data;
using JamesThew.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Security.Claims;

namespace JamesThew.Web.Controllers
{
    public class ContestsController : Controller
    {
        private readonly JamesThewDbContext _context;
        private readonly IWebHostEnvironment _environment;
        private readonly ILogger<ContestsController> _logger;

        public ContestsController(JamesThewDbContext context, IWebHostEnvironment environment, ILogger<ContestsController> logger)
        {
            _context = context;
            _environment = environment;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            ViewData["Title"] = "Active Culinary Contests - Chef James Thew";

            var activeContests = await _context.Contests
                .Include(c => c.Entries)
                .Where(c => c.Status == "Active")
                .OrderBy(c => c.EndDate)
                .ToListAsync();

            var pastContests = await _context.Contests
                .Include(c => c.Entries)
                .Where(c => c.Status == "Closed")
                .OrderByDescending(c => c.EndDate)
                .Take(4)
                .ToListAsync();

            ViewBag.PastContests = pastContests;
            return View(activeContests);
        }

        [HttpGet]
        public async Task<IActionResult> PastWinners()
        {
            ViewData["Title"] = "Hall of Fame - Past Contest Winners";

            var winners = await _context.ContestEntries
                .Include(e => e.Contest)
                .Include(e => e.User)
                .Include(e => e.Category)
                .Include(e => e.WinnerAnnouncement)
                .Where(e => e.Status == "Winner")
                .OrderByDescending(e => e.SubmittedAt)
                .ToListAsync();

            return View(winners);
        }

        [HttpGet("Contests/Submit/{id?}")]
        public IActionResult SubmitAlias(int? id)
        {
            return RedirectToAction(nameof(Participate), new { contestId = id });
        }

        [HttpGet]
        public async Task<IActionResult> Participate(int? contestId)
        {
            ViewData["Title"] = "Submit Contest Entry - James Thew Culinary Challenge";

            var activeContests = await _context.Contests
                .Where(c => c.Status == "Active")
                .OrderBy(c => c.EndDate)
                .ToListAsync();

            var categories = await _context.Categories.OrderBy(c => c.Name).ToListAsync();

            ViewBag.ActiveContests = activeContests;
            ViewBag.Categories = categories;
            ViewBag.SelectedContestId = contestId ?? activeContests.FirstOrDefault()?.Id;

            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Participate(int contestId, string entryType, string submitter_name, string submitter_email, string entry_title, int entry_category, string? recipe_ingredients, string? cooking_procedure, string? tip_description, IFormFile? entry_photo)
        {
            ViewData["Title"] = "Submit Contest Entry";

            var contest = await _context.Contests.FindAsync(contestId);
            if (contest == null || contest.Status != "Active")
            {
                TempData["ErrorMessage"] = "The selected contest is not currently active for submissions.";
                return RedirectToAction(nameof(Index));
            }

            if (string.IsNullOrWhiteSpace(entry_title))
            {
                TempData["ErrorMessage"] = "Please enter an entry title.";
                return RedirectToAction(nameof(Participate), new { contestId });
            }

            if (!string.IsNullOrWhiteSpace(submitter_name))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(submitter_name.Trim(), @"^[a-zA-Z\s]{2,50}$"))
                {
                    TempData["ErrorMessage"] = "Please enter a valid submitter name (letters and spaces only, 2 to 50 characters).";
                    return RedirectToAction(nameof(Participate), new { contestId });
                }
            }

            if (!string.IsNullOrWhiteSpace(submitter_email))
            {
                if (!System.Text.RegularExpressions.Regex.IsMatch(submitter_email.Trim(), @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
                {
                    TempData["ErrorMessage"] = "Please enter a valid email address (e.g. name@domain.com).";
                    return RedirectToAction(nameof(Participate), new { contestId });
                }
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

            string imagePath = string.Empty;
            if (entry_photo != null && entry_photo.Length > 0)
            {
                var uploadsFolder = Path.Combine(_environment.WebRootPath, "uploads", "contests");
                if (!Directory.Exists(uploadsFolder))
                {
                    Directory.CreateDirectory(uploadsFolder);
                }

                var uniqueFileName = $"{Guid.NewGuid()}_{Path.GetFileName(entry_photo.FileName)}";
                var filePath = Path.Combine(uploadsFolder, uniqueFileName);

                using (var stream = new FileStream(filePath, FileMode.Create))
                {
                    await entry_photo.CopyToAsync(stream);
                }

                imagePath = $"/uploads/contests/{uniqueFileName}";
            }

            var entry = new ContestEntry
            {
                ContestId = contestId,
                UserId = currentUserId,
                GuestName = !string.IsNullOrWhiteSpace(submitter_name) ? submitter_name.Trim() : (User.Identity?.Name ?? "Guest Gourmand"),
                GuestEmail = !string.IsNullOrWhiteSpace(submitter_email) ? submitter_email.Trim().ToLower() : (User.FindFirstValue(ClaimTypes.Email) ?? "contest@jamesthew.com"),
                EntryType = string.IsNullOrWhiteSpace(entryType) ? "Recipe" : (entryType.Equals("tip", StringComparison.OrdinalIgnoreCase) ? "Tip" : "Recipe"),
                Title = entry_title.Trim(),
                CategoryId = entry_category > 0 ? entry_category : null,
                Ingredients = recipe_ingredients?.Trim() ?? string.Empty,
                Procedure = cooking_procedure?.Trim() ?? string.Empty,
                Description = tip_description?.Trim() ?? string.Empty,
                ImagePath = imagePath,
                Status = "Pending",
                SubmittedAt = DateTime.UtcNow
            };

            _context.ContestEntries.Add(entry);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Congratulations! Your contest submission has been received. Our executive tasting panel will judge all entries upon competition closing.";
            return RedirectToAction(nameof(Index));
        }
    }
}
