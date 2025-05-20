using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.StationaryIZAV
{
    public class StationaryIZAVDTO
    {
        [Key]
        [Required]
        public int StationaryIZAVID { get; set; }

        [Required]
        public int? SectorID { get; set; }

        [Required]
        public string Type { get; set; } = string.Empty;

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public short AmountOfIZAVWithOneNumber { get; set; }

        [Required]
        public float IZAVHeight { get; set; }

        public float EstuaryDiameter { get; set; }

        [Required]
        public int NumberInCompany { get; set; }

        public float EstuaryLength { get; set; }

        public float EstuaryWidth { get; set; }

        public float ArealZAVWidth { get; set; }

        public short ModeNumber { get; set; }

        [Required]
        public float OutputSpeedOfGAM { get; set; }

        [Required]
        public float VolumeOfGAM { get; set; }

        [Required]
        public short TemperatureOfGAM { get; set; }

        [Required]
        public float DensityOfGAM { get; set; }
    }
}
