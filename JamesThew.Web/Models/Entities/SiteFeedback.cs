using System;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class SiteFeedback
    {
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [MaxLength(200)]
        public string Subject { get; set; } = string.Empty;
        
        [Required, MaxLength(50)]
        public string Category { get; set; } = string.Empty;
        
        public int Rating { get; set; }
        
        [Required]
        public string Comments { get; set; } = string.Empty;
        
        public bool ShowOnHome { get; set; }
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
