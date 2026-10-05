using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string FullName { get; set; } = string.Empty;
        
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [MaxLength(20)]
        public string Phone { get; set; } = string.Empty;
        
        [Required]
        public string PasswordHash { get; set; } = string.Empty;
        
        [Required, MaxLength(20)]
        public string Role { get; set; } = string.Empty; // Free, Member, Admin
        
        [MaxLength(255)]
        public string AvatarPath { get; set; } = string.Empty;
        
        public bool IsBlocked { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Subscription> Subscriptions { get; set; } = new List<Subscription>();
        public virtual ICollection<Recipe> Recipes { get; set; } = new List<Recipe>();
        public virtual ICollection<Tip> Tips { get; set; } = new List<Tip>();
        public virtual ICollection<ContestEntry> ContestEntries { get; set; } = new List<ContestEntry>();
        public virtual ICollection<RecipeFeedback> RecipeFeedbacks { get; set; } = new List<RecipeFeedback>();
    }
}
