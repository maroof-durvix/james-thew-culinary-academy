using JamesThew.Web.Data;
using JamesThew.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JamesThew.Web.Controllers
{
    public class AnnouncementsController : Controller
    {
        private readonly JamesThewDbContext _context;
        private readonly ILogger<AnnouncementsController> _logger;

        public AnnouncementsController(JamesThewDbContext context, ILogger<AnnouncementsController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public async Task<IActionResult> Index(string? filter = null)
        {
            ViewData["Title"] = "Announcements & Guild News - Chef James Thew";

            var announcements = await _context.Announcements
                .Include(a => a.Contest)
                .Include(a => a.WinnerEntry)
                    .ThenInclude(w => w.User)
                .OrderByDescending(a => a.PostedAt)
                .ToListAsync();

            var activeContests = await _context.Contests
                .Where(c => c.Status == "Active")
                .OrderBy(c => c.EndDate)
                .Take(3)
                .ToListAsync();

            ViewBag.ActiveContests = activeContests;
            ViewBag.CurrentFilter = filter?.ToLower() ?? "all";

            return View(announcements);
        }
    }
}
