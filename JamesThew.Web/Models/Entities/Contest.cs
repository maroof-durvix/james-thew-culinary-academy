using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class Contest
    {
        public int Id { get; set; }
        
        [Required, MaxLength(200)]
        public string Title { get; set; } = string.Empty;
        
        [Required]
        public string Description { get; set; } = string.Empty;
        
        [Required, MaxLength(50)]
        public string EntryType { get; set; } = string.Empty; // Recipe, Tip, Both
        
        [MaxLength(255)]
        public string Prize { get; set; } = string.Empty;
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        [Required, MaxLength(20)]
        public string Status { get; set; } = string.Empty; // Active, Closed
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ContestEntry> Entries { get; set; } = new List<ContestEntry>();
        public virtual ICollection<Announcement> Announcements { get; set; } = new List<Announcement>();
    }
}
