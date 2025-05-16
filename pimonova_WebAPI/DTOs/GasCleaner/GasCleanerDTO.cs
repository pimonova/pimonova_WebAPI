using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.GasCleaner
{
    public class GasCleanerDTO
    {
        [Key]
        [Required]
        public int GasCleanerID { get; set; }

        [Required]
        public int? SectorID { get; set; }

        [Required]
        public int NumberInCompany { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string Brand { get; set; } = string.Empty;

        [Required]
        public int? StationaryIZAVToOut { get; set; }
    }
}
