using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.User
{
    public class CreateUserRequestDTO
    {
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
