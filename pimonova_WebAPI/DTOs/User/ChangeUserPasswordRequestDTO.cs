using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.User
{
    public class ChangeUserPasswordRequestDTO
    {
        [Required]
        public string CurrentPassword { get; set; } = string.Empty;
        [Required]
        public string NewPassword { get; set; } = string.Empty;
    }
}
