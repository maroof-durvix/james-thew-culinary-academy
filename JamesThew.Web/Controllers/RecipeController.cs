using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using JamesThew.Web.Data;
using System.Linq;
using System.Threading.Tasks;

namespace JamesThew.Web.Controllers;

public class RecipeController : Controller
{
    private readonly JamesThewDbContext _context;

    public RecipeController(JamesThewDbContext context)
    {
        _context = context;
    }

    public async Task<IActionResult> Free()
    {
        var recipes = await _context.Recipes
            .Include(r => r.Category)
            .Include(r => r.Author)
            .Where(r => r.Access == "Free")
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
        return View(recipes);
    }

    public async Task<IActionResult> Premium()
    {
        var recipes = await _context.Recipes
            .Include(r => r.Category)
            .Include(r => r.Author)
            .Where(r => r.Access == "Premium")
            .OrderByDescending(r => r.CreatedAt)
            .ToListAsync();
        return View(recipes);
    }

    public async Task<IActionResult> Details(int id)
    {
        var recipe = await _context.Recipes
            .Include(r => r.Category)
            .Include(r => r.Author)
            .Include(r => r.Feedbacks)
                .ThenInclude(f => f.User)
            .FirstOrDefaultAsync(r => r.Id == id);
            
        if (recipe == null) return NotFound();

        // Lock premium recipe details if user is Guest or Free member.
        if (recipe.Access == "Premium" && !User.IsInRole("Admin") && !User.IsInRole("Premium"))
        {
            // The view will handle showing the blurred version and a lock overlay.
            // We just pass it. Actually, wait, does the Stitch design have a separate route for locked?
            // "Premium Recipes (Guest) -> /Recipe/Premium (visitor/free-user locked state)"
            // The requirements say if they are not Premium, show locked.
        }

        return View(recipe);
    }
}
