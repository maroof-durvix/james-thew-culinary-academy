#pragma warning disable CS8618
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
