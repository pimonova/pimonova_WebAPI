using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pimonova_WebAPI.Models
{
    [Table("StationaryIZAVs")]
    public class StationaryIZAV
    {
        [Key]
        public int StationaryIZAVID { get; set; }

        public int? SectorID { get; set; }
        public virtual Sector? Sector { get; set; }

        public string Type { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public short AmountOfIZAVWithOneNumber { get; set; }

        public float IZAVHeight { get; set; }

        public float EstuaryDiameter { get; set; }

        public int NumberInCompany { get; set; }

        public float EstuaryLength { get; set; }

        public float EstuaryWidth { get; set; }

        public float ArealZAVWidth { get; set; }

        public short ModeNumber { get; set; }

        public float OutputSpeedOfGAM { get; set; } // Скорость выхода ГВС

        public float VolumeOfGAM { get; set; } // Объем (расход) ГВС

        public short TemperatureOfGAM { get; set; } 

        public float DensityOfGAM { get; set; } // Полность ГВС

        public virtual ICollection<GasCleaner> GasCleaners { get; set; } = new List<GasCleaner>();

        public virtual ICollection<InstrumentalEmissionMeasuring> InstrumentalEmissionMeasuringsOfSIZAV { get; set; } = new List<InstrumentalEmissionMeasuring>();

        public virtual ICollection<SourceOfPollutants> SourcesOfPollutants { get; set; } = new List<SourceOfPollutants>();

        public virtual ICollection<StationaryIZAV_Pollutant> StationaryIZAVs_Pollutants { get; set; } = new List<StationaryIZAV_Pollutant>();
    }
}
