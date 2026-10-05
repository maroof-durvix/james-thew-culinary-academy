using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class PasswordResetToken
    {
        public int Id { get; set; }
        
        public int UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [Required, MaxLength(255)]
        public string TokenHash { get; set; } = string.Empty;
        
        public DateTime ExpiresAt { get; set; }
        public DateTime? UsedAt { get; set; }
    }
}
