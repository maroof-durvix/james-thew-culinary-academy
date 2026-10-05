import os

models_dir = 'c:/Users/Ahmed Durwesh/Desktop/E project 3/JamesThew/JamesThew.Web/Models/Entities'
os.makedirs(models_dir, exist_ok=True)

models = {
    "User.cs": """using System;
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
""",
    "Subscription.cs": """using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class Subscription
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        [Required, MaxLength(50)]
        public string Plan { get; set; }
        
        [Column(TypeName = "decimal(18,2)")]
        public decimal Amount { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime ExpiryDate { get; set; }
        
        [Required, MaxLength(50)]
        public string PaymentStatus { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
""",
    "Category.cs": """using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Tip> Tips { get; set; }
        public virtual ICollection<ContestEntry> ContestEntries { get; set; }
    }
}
""",
    "Recipe.cs": """using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class Recipe
    {
        public int Id { get; set; }
        
        [Required, MaxLength(200)]
        public string Title { get; set; }
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        
        [Required]
        public string Ingredients { get; set; }
        
        [Required]
        public string Procedure { get; set; }
        
        public int PrepMinutes { get; set; }
        public int CookMinutes { get; set; }
        
        [MaxLength(255)]
        public string ImagePath { get; set; }
        
        [Required, MaxLength(20)]
        public string Access { get; set; } // Free, Premium
        
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
        public DateTime UpdatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<RecipeFeedback> Feedbacks { get; set; }
    }
}
""",
    "Tip.cs": """using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class Tip
    {
        public int Id { get; set; }
        
        [Required, MaxLength(200)]
        public string Title { get; set; }
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [MaxLength(255)]
        public string ImagePath { get; set; }
        
        [Required, MaxLength(20)]
        public string Access { get; set; } // Free, Premium
        
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
""",
    "Contest.cs": """using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class Contest
    {
        public int Id { get; set; }
        
        [Required, MaxLength(200)]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required, MaxLength(50)]
        public string EntryType { get; set; } // Recipe, Tip, Both
        
        [MaxLength(255)]
        public string Prize { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        [Required, MaxLength(20)]
        public string Status { get; set; } // Active, Closed
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ContestEntry> Entries { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
""",
    "ContestEntry.cs": """using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class ContestEntry
    {
        public int Id { get; set; }
        
        public int ContestId { get; set; }
        [ForeignKey("ContestId")]
        public virtual Contest Contest { get; set; }
        
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        [MaxLength(100)]
        public string GuestName { get; set; }
        
        [MaxLength(255), EmailAddress]
        public string GuestEmail { get; set; }
        
        [Required, MaxLength(50)]
        public string EntryType { get; set; }
        
        [Required, MaxLength(200)]
        public string Title { get; set; }
        
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; }
        
        public string Ingredients { get; set; }
        public string Procedure { get; set; }
        public string Description { get; set; }
        
        [MaxLength(255)]
        public string ImagePath { get; set; }
        
        [Required, MaxLength(20)]
        public string Status { get; set; } // Pending, Winner
        
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public virtual Announcement WinnerAnnouncement { get; set; }
    }
}
""",
    "Announcement.cs": """using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Type { get; set; } // Winner, Update, NewContest
        
        [Required, MaxLength(200)]
        public string Title { get; set; }
        
        [Required]
        public string Message { get; set; }
        
        public int? ContestId { get; set; }
        [ForeignKey("ContestId")]
        public virtual Contest Contest { get; set; }
        
        public int? WinnerEntryId { get; set; }
        [ForeignKey("WinnerEntryId")]
        public virtual ContestEntry WinnerEntry { get; set; }
        
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
    }
}
""",
    "RecipeFeedback.cs": """using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class RecipeFeedback
    {
        public int Id { get; set; }
        
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; }
        
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        [MaxLength(100)]
        public string Name { get; set; }
        
        [MaxLength(255), EmailAddress]
        public string Email { get; set; }
        
        public int Rating { get; set; } // 1 to 5
        
        [Required]
        public string Comment { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
""",
    "SiteFeedback.cs": """using System;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class SiteFeedback
    {
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; }
        
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }
        
        [MaxLength(200)]
        public string Subject { get; set; }
        
        [Required, MaxLength(50)]
        public string Category { get; set; }
        
        public int Rating { get; set; }
        
        [Required]
        public string Comments { get; set; }
        
        public bool ShowOnHome { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
""",
    "ContactMessage.cs": """using System;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class ContactMessage
    {
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; }
        
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; }
        
        [Required]
        public string Message { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
""",
    "Faq.cs": """using System;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class Faq
    {
        public int Id { get; set; }
        
        [Required, MaxLength(500)]
        public string Question { get; set; }
        
        [Required]
        public string Answer { get; set; }
        
        public int DisplayOrder { get; set; }
    }
}
""",
    "PasswordResetToken.cs": """using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class PasswordResetToken
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; }
        
        [Required, MaxLength(255)]
        public string TokenHash { get; set; }
        
        public DateTime ExpiresAt { get; set; }
        public DateTime? UsedAt { get; set; }
    }
}
"""
}

for name, content in models.items():
    with open(os.path.join(models_dir, name), 'w') as f:
        f.write(content)

print("Entities created successfully.")
