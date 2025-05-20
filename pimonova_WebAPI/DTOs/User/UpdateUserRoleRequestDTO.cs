using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.User
{
    public class UpdateUserRoleRequestDTO
    {
        [Required]
        public string Role { get; set; } = string.Empty;
    }
}
