using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    public class User
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
        public string Role { get; set; } = string.Empty; // права доступа (в приложении)

        [Required]
        public string Position { get; set; } = string.Empty; // должность в компании

        [Required]
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }
    }
}
