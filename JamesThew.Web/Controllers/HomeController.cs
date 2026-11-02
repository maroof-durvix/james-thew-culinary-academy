using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JamesThew.Web.Data;
using JamesThew.Web.Models;

namespace JamesThew.Web.Controllers;

public class HomeController : Controller
{
    private readonly JamesThewDbContext _context;
    private readonly ILogger<HomeController> _logger;

    public HomeController(JamesThewDbContext context, ILogger<HomeController> logger)
    {
        _context = context;
        _logger = logger;
    }

    public async Task<IActionResult> Index()
    {
        ViewData["Title"] = "Master Culinary Arts - Chef James Thew";

        var featuredRecipes = await _context.Recipes
            .Include(r => r.Category)
            .Include(r => r.Author)
            .Include(r => r.Feedbacks)
            .Where(r => r.Access == "Free")
            .OrderByDescending(r => r.CreatedAt)
            .Take(4)
            .ToListAsync();

        var activeContest = await _context.Contests
            .Include(c => c.Entries)
            .FirstOrDefaultAsync(c => c.Status == "Active");

        var latestWinner = await _context.ContestEntries
            .Include(e => e.Contest)
            .Include(e => e.User)
            .Include(e => e.Category)
            .OrderByDescending(e => e.SubmittedAt)
            .FirstOrDefaultAsync(e => e.Status == "Winner");

        var testimonials = await _context.SiteFeedbacks
            .Where(f => f.ShowOnHome)
            .OrderByDescending(f => f.CreatedAt)
            .Take(3)
            .ToListAsync();

        ViewBag.FeaturedRecipes = featuredRecipes;
        ViewBag.ActiveContest = activeContest;
        ViewBag.LatestWinner = latestWinner;
        ViewBag.Testimonials = testimonials;
        ViewBag.TotalRecipes = await _context.Recipes.CountAsync();
        ViewBag.TotalUsers = await _context.Users.CountAsync();

        return View();
    }

    public IActionResult Privacy()
    {
        return RedirectToAction("Privacy", "Legal");
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
}
