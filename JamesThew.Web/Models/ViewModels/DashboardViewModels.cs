using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using JamesThew.Web.Models.Entities;

namespace JamesThew.Web.Models.ViewModels
{
    public class DashboardHomeViewModel
    {
        public User User { get; set; } = null!;
        public int MyRecipesCount { get; set; }
        public int MyTipsCount { get; set; }
        public int MyEntriesCount { get; set; }
        public Subscription? ActiveSubscription { get; set; }
        public List<Recipe> RecentRecipes { get; set; } = new();
        public List<Tip> RecentTips { get; set; } = new();
    }

    public class AddRecipeViewModel
    {
        [Required(ErrorMessage = "Recipe title is required")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Ingredients are required")]
        public string Ingredients { get; set; } = string.Empty;

        [Required(ErrorMessage = "Preparation procedure is required")]
        public string Procedure { get; set; } = string.Empty;

        [Range(1, 1440, ErrorMessage = "Prep minutes must be at least 1")]
        public int PrepMinutes { get; set; } = 15;

        [Range(0, 1440, ErrorMessage = "Cook minutes cannot be negative")]
        public int CookMinutes { get; set; } = 30;

        [Required]
        public string Access { get; set; } = "Free"; // "Free" or "Premium"

        public IFormFile? ImageFile { get; set; }

        public IEnumerable<Category>? AvailableCategories { get; set; }
    }

    public class AddTipViewModel
    {
        [Required(ErrorMessage = "Tip title is required")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Please select a category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Detailed description/technique is required")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Access { get; set; } = "Free"; // "Free" or "Premium"

        public IFormFile? ImageFile { get; set; }

        public IEnumerable<Category>? AvailableCategories { get; set; }
    }

    public class ProfileViewModel
    {
        [Required(ErrorMessage = "Full Name is required")]
        [MaxLength(100)]
        public string FullName { get; set; } = string.Empty;

        [Required(ErrorMessage = "Email is required")]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;

        public string? AvatarPath { get; set; }
        public string Role { get; set; } = "Free";
        public Subscription? ActiveSubscription { get; set; }

        public IFormFile? AvatarFile { get; set; }

        [DataType(DataType.Password)]
        public string? CurrentPassword { get; set; }

        [DataType(DataType.Password)]
        [MinLength(6, ErrorMessage = "New password must be at least 6 characters")]
        public string? NewPassword { get; set; }

        [DataType(DataType.Password)]
        [Compare("NewPassword", ErrorMessage = "Passwords do not match")]
        public string? ConfirmPassword { get; set; }
    }
}
