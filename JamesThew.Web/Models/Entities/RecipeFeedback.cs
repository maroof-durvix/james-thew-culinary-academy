#pragma warning disable CS8618
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
