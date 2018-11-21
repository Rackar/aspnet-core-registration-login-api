using System;
using System.ComponentModel.DataAnnotations;
namespace WebApi.Entities
{
    public class User
    {
         [Key]
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        [Required]
        public string Username { get; set; }
        public byte[] PasswordHash { get; set; }
        public byte[] PasswordSalt { get; set; }
        [Required]
        public DateTime Date { get; set; }

        [Required]
        public string Email { get; set; }
        [Required]
        public string Rights { get; set; }

    }
}