using System;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class ContactMessage
    {
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; } = string.Empty;
        
        [Required, MaxLength(255), EmailAddress]
        public string Email { get; set; } = string.Empty;
        
        [Required]
        public string Message { get; set; } = string.Empty;
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;
    }
}
