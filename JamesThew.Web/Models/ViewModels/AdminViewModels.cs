using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using Microsoft.AspNetCore.Http;
using JamesThew.Web.Models.Entities;

namespace JamesThew.Web.Models.ViewModels
{
    public class AdminDashboardViewModel
    {
        public int TotalRecipes { get; set; }
        public int TotalTips { get; set; }
        public int TotalUsers { get; set; }
        public int TotalMembers { get; set; }
        public int TotalContests { get; set; }
        public int TotalContestEntries { get; set; }
        public int TotalFeedbacks { get; set; }
        public List<Recipe> RecentRecipes { get; set; } = new();
        public List<ContestEntry> RecentEntries { get; set; } = new();
        public List<User> RecentUsers { get; set; } = new();
    }

    public class AdminRecipeFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Recipe title is required")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category selection is required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Ingredients are required")]
        public string Ingredients { get; set; } = string.Empty;

        [Required(ErrorMessage = "Procedure is required")]
        public string Procedure { get; set; } = string.Empty;

        [Range(1, 1440)]
        public int PrepMinutes { get; set; } = 15;

        [Range(0, 1440)]
        public int CookMinutes { get; set; } = 30;

        [Required]
        public string Access { get; set; } = "Free";

        public string? CurrentImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }

        public IEnumerable<Category>? Categories { get; set; }
    }

    public class AdminTipFormViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "Tip title is required")]
        [MaxLength(200)]
        public string Title { get; set; } = string.Empty;

        [Required(ErrorMessage = "Category selection is required")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }

        [Required(ErrorMessage = "Description is required")]
        public string Description { get; set; } = string.Empty;

        [Required]
        public string Access { get; set; } = "Free";

        public string? CurrentImagePath { get; set; }
        public IFormFile? ImageFile { get; set; }

        public IEnumerable<Category>? Categories { get; set; }
    }
}
