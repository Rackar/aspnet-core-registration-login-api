using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class article
    {
        [Key]
        public int id { get; set; }
        [Required]
        public int user_id { get; set; }
        [Required]
        public string category { get; set; }
        [Required]
        public string title { get; set; }
        [Required]
        public string content { get; set; }
        [Required]
        public int view_counts { get; set; }
        [Required]
        public DateTime date { get; set; }
    }
}
