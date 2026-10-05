using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class Tip
    {
        public int Id { get; set; }
        
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        
        public int CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        [MaxLength(255)]
        public string ImagePath { get; set; } = string.Empty;
        
        [Required, MaxLength(20)]
        public string Access { get; set; } = string.Empty; // Free, Premium
        
        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public virtual User Author { get; set; } = null!;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
