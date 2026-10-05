using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class User
    {
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string FullName { get; set; }
        
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(20)]
        public string Phone { get; set; }
        
        [Required]
        public string PasswordHash { get; set; }
        
        [Required, MaxLength(20)]
        public string Role { get; set; } // Free, Member, Admin
        
        [MaxLength(255)]
        public string AvatarPath { get; set; }
        
        public bool IsBlocked { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        // Navigation properties
        public virtual ICollection<Subscription> Subscriptions { get; set; }
        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Tip> Tips { get; set; }
        public virtual ICollection<ContestEntry> ContestEntries { get; set; }
        public virtual ICollection<RecipeFeedback> RecipeFeedbacks { get; set; }
    }
}
