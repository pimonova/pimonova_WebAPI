using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.User
{
    public class UserWithLoginDTO
    {
        [Key]
        [Required]
        public int UserID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Surname { get; set; } = string.Empty;

        [Required]
        public string Login { get; set; } = string.Empty;

        [Required]
        public int? CompanyID { get; set; }

        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
