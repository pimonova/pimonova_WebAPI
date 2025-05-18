using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.SourceOfPollutants
{
    public class CreateSourceOfPollutantsRequestDTO
    {
        [Required]
        public int? SectorID { get; set; }

        [Required]
        public int NumberInCompany { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public short? ModeNumber { get; set; }

        [Required]
        public short WorkingHoursPerDay { get; set; }

        [Required]
        public short WorkingHoursPerYear { get; set; }

        [Required]
        public short AmountOfSOPWithOneNumber { get; set; }

        public int? GasCleanerID { get; set; }

        [Required]
        public int? StationaryIZAVID { get; set; }
    }
}
