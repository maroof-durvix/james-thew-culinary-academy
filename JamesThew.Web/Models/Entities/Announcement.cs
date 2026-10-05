using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Type { get; set; } = string.Empty; // Winner, Update, NewContest
        
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Message { get; set; } = string.Empty;
        
        public int? ContestId { get; set; }
        [ForeignKey("ContestId")]
        public virtual Contest Contest { get; set; } = null!;
        
        public int? WinnerEntryId { get; set; }
        [ForeignKey("WinnerEntryId")]
        public virtual ContestEntry WinnerEntry { get; set; } = null!;
        
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
    }
}
