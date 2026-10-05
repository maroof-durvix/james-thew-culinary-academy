using System;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class Faq
    {
        public int Id { get; set; }
        
        [Required, MaxLength(500)]
        public string Question { get; set; } = string.Empty;
        
        [Required]
        public string Answer { get; set; } = string.Empty;
        
        public int DisplayOrder { get; set; }
    }
}
