using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Article
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int User_id { get; set; }
        // [Required]
        public string Category { get; set; }
        [Required]
        public string Title { get; set; }
        // [Required]
        public string Content { get; set; }
        
        public int View_counts { get; set; }
        // [Required]
        public string Date { get; set; }
    }
}
