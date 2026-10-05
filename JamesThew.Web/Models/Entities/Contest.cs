#pragma warning disable CS8618
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class Contest
    {
        public int Id { get; set; }
        
        [Required, MaxLength(200)]
        public string Title { get; set; }
        
        [Required]
        public string Description { get; set; }
        
        [Required, MaxLength(50)]
        public string EntryType { get; set; } // Recipe, Tip, Both
        
        [MaxLength(255)]
        public string Prize { get; set; }
        
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        
        [Required, MaxLength(20)]
        public string Status { get; set; } // Active, Closed
        
        public DateTime CreatedAt { get; set; } = DateTime.UtcNow;

        public virtual ICollection<ContestEntry> Entries { get; set; }
        public virtual ICollection<Announcement> Announcements { get; set; }
    }
}
