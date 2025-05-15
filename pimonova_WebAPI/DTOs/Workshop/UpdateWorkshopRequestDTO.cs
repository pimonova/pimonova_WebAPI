using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.Workshop
{
    public class UpdateWorkshopRequestDTO
    {
        [Required]
        public int NumberInCompany { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
