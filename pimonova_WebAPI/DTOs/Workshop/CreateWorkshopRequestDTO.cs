using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.Workshop
{
    public class CreateWorkshopRequestDTO
    {
        [Required]
        public int NumberInCompany { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
