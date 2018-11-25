using System;
using System.ComponentModel.DataAnnotations;

namespace WebApi.Entities
{
    public class Comment
    {
        [Key]
        public int Id { get; set; }
        [Required]
        public int User_id { get; set; }
        [Required]
        public int article_id { get; set; }
                
        public string Content { get; set; }
        
        public string Date { get; set; }
    }
}
