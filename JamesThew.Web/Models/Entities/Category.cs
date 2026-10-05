using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace JamesThew.Web.Models.Entities
{
    public class Category
    {
        public int Id { get; set; }
        
        [Required, MaxLength(100)]
        public string Name { get; set; }

        public virtual ICollection<Recipe> Recipes { get; set; }
        public virtual ICollection<Tip> Tips { get; set; }
        public virtual ICollection<ContestEntry> ContestEntries { get; set; }
    }
}
