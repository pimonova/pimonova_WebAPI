using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.Sector
{
    public class UpdateSectorRequestDTO
    {
        [Required]
        public int NumberInCompany { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
