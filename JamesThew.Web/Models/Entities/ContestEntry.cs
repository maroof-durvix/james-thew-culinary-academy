using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class ContestEntry
    {
        public int Id { get; set; }
        
        public int ContestId { get; set; }
        [ForeignKey("ContestId")]
        public virtual Contest Contest { get; set; } = null!;
        
        public int? UserId { get; set; }
        [ForeignKey("UserId")]
        public virtual User User { get; set; } = null!;
        
        [MaxLength(100)]
        public string GuestName { get; set; } = string.Empty;
        
        [MaxLength(255), EmailAddress]
        public string GuestEmail { get; set; } = string.Empty;
        
        [Required, MaxLength(50)]
        public string EntryType { get; set; } = string.Empty;
        
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        
        public int? CategoryId { get; set; }
        [ForeignKey("CategoryId")]
        public virtual Category Category { get; set; } = null!;
        
        public string Ingredients { get; set; } = string.Empty;
        public string Procedure { get; set; } = string.Empty;
        public string Description { get; set; } = string.Empty;
        
        [MaxLength(255)]
        public string ImagePath { get; set; } = string.Empty;
        
        [Required, MaxLength(20)]
        public string Status { get; set; } = string.Empty; // Pending, Winner
        
        public DateTime SubmittedAt { get; set; } = DateTime.UtcNow;

        public virtual Announcement WinnerAnnouncement { get; set; } = null!;
    }
}
