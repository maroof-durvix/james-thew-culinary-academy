using System;
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
