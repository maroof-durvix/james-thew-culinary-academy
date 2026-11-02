using JamesThew.Web.Data;
using JamesThew.Web.Models.Entities;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace JamesThew.Web.Controllers
{
    public class HelpController : Controller
    {
        private readonly JamesThewDbContext _context;
        private readonly ILogger<HelpController> _logger;

        public HelpController(JamesThewDbContext context, ILogger<HelpController> logger)
        {
            _context = context;
            _logger = logger;
        }

        [HttpGet]
        public IActionResult Index()
        {
            return RedirectToAction(nameof(Faq));
        }

        [HttpGet]
        public async Task<IActionResult> Faq()
        {
            ViewData["Title"] = "Frequently Asked Questions";
            var faqs = await _context.Faqs.OrderBy(f => f.DisplayOrder).ToListAsync();
            return View(faqs);
        }

        [HttpGet]
        public async Task<IActionResult> Feedback()
        {
            ViewData["Title"] = "Give Feedback";
            var recentFeedbacks = await _context.SiteFeedbacks
                .OrderByDescending(f => f.CreatedAt)
                .Take(5)
                .ToListAsync();
            ViewBag.RecentFeedbacks = recentFeedbacks;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Feedback(string userName, string userEmail, string subject, string category, int? rating, string comments)
        {
            ViewData["Title"] = "Give Feedback";

            if (string.IsNullOrWhiteSpace(userName) || string.IsNullOrWhiteSpace(userEmail) || string.IsNullOrWhiteSpace(comments))
            {
                TempData["ErrorMessage"] = "Please fill in all required fields (Name, Email, Comments).";
                return RedirectToAction("Feedback");
            }

            userName = userName.Trim();
            userEmail = userEmail.Trim().ToLower();

            if (!System.Text.RegularExpressions.Regex.IsMatch(userName, @"^[a-zA-Z\s]{2,50}$"))
            {
                TempData["ErrorMessage"] = "Please enter a valid name (letters and spaces only, 2 to 50 characters).";
                return RedirectToAction("Feedback");
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(userEmail, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                TempData["ErrorMessage"] = "Please enter a valid email address (e.g. name@domain.com).";
                return RedirectToAction("Feedback");
            }

            if (comments.Trim().Length < 5)
            {
                TempData["ErrorMessage"] = "Please provide a meaningful feedback comment (at least 5 characters).";
                return RedirectToAction("Feedback");
            }

            var feedback = new SiteFeedback
            {
                Name = userName,
                Email = userEmail,
                Subject = subject?.Trim() ?? "General Feedback",
                Category = string.IsNullOrWhiteSpace(category) ? "General" : category.Trim(),
                Rating = rating.HasValue && rating.Value >= 1 && rating.Value <= 5 ? rating.Value : 5,
                Comments = comments.Trim(),
                ShowOnHome = true,
                CreatedAt = DateTime.UtcNow
            };

            _context.SiteFeedbacks.Add(feedback);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Thank you! Your feedback has been received and forwarded to Chef James's team.";
            return RedirectToAction("Feedback");
        }

        [HttpGet]
        public IActionResult Contact()
        {
            ViewData["Title"] = "Contact Us";
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Contact(string firstName, string lastName, string email, string phone, string message)
        {
            ViewData["Title"] = "Contact Us";

            if (string.IsNullOrWhiteSpace(firstName) || string.IsNullOrWhiteSpace(email) || string.IsNullOrWhiteSpace(message))
            {
                TempData["ErrorMessage"] = "Please provide your first name, email, and message.";
                return RedirectToAction(nameof(Contact));
            }

            firstName = firstName.Trim();
            email = email.Trim().ToLower();

            if (!System.Text.RegularExpressions.Regex.IsMatch(firstName, @"^[a-zA-Z\s]{2,50}$"))
            {
                TempData["ErrorMessage"] = "Please enter a valid first name (letters and spaces only, 2 to 50 characters).";
                return RedirectToAction(nameof(Contact));
            }

            if (!string.IsNullOrWhiteSpace(lastName))
            {
                lastName = lastName.Trim();
                if (!System.Text.RegularExpressions.Regex.IsMatch(lastName, @"^[a-zA-Z\s]{1,50}$"))
                {
                    TempData["ErrorMessage"] = "Please enter a valid last name (letters and spaces only).";
                    return RedirectToAction(nameof(Contact));
                }
            }

            if (!System.Text.RegularExpressions.Regex.IsMatch(email, @"^[a-zA-Z0-9._%+-]+@[a-zA-Z0-9.-]+\.[a-zA-Z]{2,}$"))
            {
                TempData["ErrorMessage"] = "Please enter a valid email address (e.g. name@domain.com).";
                return RedirectToAction(nameof(Contact));
            }

            if (!string.IsNullOrWhiteSpace(phone))
            {
                phone = phone.Trim();
                var digitsOnly = System.Text.RegularExpressions.Regex.Replace(phone, @"[^\d]", "");
                if (!System.Text.RegularExpressions.Regex.IsMatch(phone, @"^[\+]?[0-9\s\-]{7,16}$") || digitsOnly.Length < 7 || digitsOnly.Length > 15)
                {
                    TempData["ErrorMessage"] = "Please enter a valid phone number (7 to 15 digits).";
                    return RedirectToAction(nameof(Contact));
                }
            }

            if (message.Trim().Length < 5)
            {
                TempData["ErrorMessage"] = "Please enter a message of at least 5 characters.";
                return RedirectToAction(nameof(Contact));
            }

            var fullName = $"{firstName} {lastName}".Trim();
            var contactMsg = new ContactMessage
            {
                Name = fullName,
                Email = email,
                Message = message.Trim() + (string.IsNullOrWhiteSpace(phone) ? "" : $" [Phone: {phone}]"),
                CreatedAt = DateTime.UtcNow
            };

            _context.ContactMessages.Add(contactMsg);
            await _context.SaveChangesAsync();

            TempData["SuccessMessage"] = "Inquiry dispatched successfully! Chef James Thew's concierge will attend to your request promptly.";
            return RedirectToAction(nameof(Contact));
        }
    }
}
