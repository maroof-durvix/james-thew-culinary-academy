using System;
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
