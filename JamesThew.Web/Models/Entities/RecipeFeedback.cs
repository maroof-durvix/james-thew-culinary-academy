using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class RecipeFeedback
    {
        public int Id { get; set; }
        
        public int RecipeId { get; set; }
        [ForeignKey("RecipeId")]
        public virtual Recipe Recipe { get; set; } = null!;
        
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [MaxLength(255), EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        public int Rating { get; set; } // 1 to 5
        
        [Required]
        public string Comment { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
