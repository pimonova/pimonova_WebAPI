using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.MobileIZAV
{
    public class CreateMobileIZAVRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public int NumberInCompany { get; set; }

        [Required]
        public short AmountOfIZAVWithOneNumber { get; set; }

        [Required]
        public short Speed { get; set; }

        [Required]
        public string Fuel { get; set; } = string.Empty;

        [Required]
        public short WorkingHoursPerSeason { get; set; }

        [Required]
        public short WorkingHoursPerYear { get; set; }
    }
}
