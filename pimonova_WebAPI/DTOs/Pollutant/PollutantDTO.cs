using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.Pollutant
{
    public class PollutantDTO
    {
        [Key]
        [Required]
        public int PollutantID { get; set; }

        [Required]
        public string Code { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
