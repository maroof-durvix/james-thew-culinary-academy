using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace JamesThew.Web.Models.Entities
{
    public class Announcement
    {
        public int Id { get; set; }
        
        [Required, MaxLength(50)]
        public string Type { get; set; } // Winner, Update, NewContest
        
        [Required, MaxLength(200)]
        public string Title { get; set; }
        
        [Required]
        public string Message { get; set; }
        
        public int? ContestId { get; set; }
        [ForeignKey("ContestId")]
        public virtual Contest Contest { get; set; }
        
        public int? WinnerEntryId { get; set; }
        [ForeignKey("WinnerEntryId")]
        public virtual ContestEntry WinnerEntry { get; set; }
        
        public DateTime PostedAt { get; set; } = DateTime.UtcNow;
    }
}
