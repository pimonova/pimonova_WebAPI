using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.User
{
    public class UserDTO
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public string Email { get; set; } = string.Empty;

        [Required]
        public string Role { get; set; } = string.Empty;

        [Required]
        public string Position { get; set; } = string.Empty;

        [Required]
        public int? CompanyID { get; set; }
    }
}
