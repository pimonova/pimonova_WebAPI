using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.Pollutant
{
    public class CreateOrUpdatePollutantRequestDTO
    {
        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
