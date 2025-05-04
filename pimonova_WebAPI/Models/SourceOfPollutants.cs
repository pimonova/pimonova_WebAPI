using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pimonova_WebAPI.Models
{
    // Источник выделения (ИВ)
    [Table("SourcesOfPollutants")]
    public class SourceOfPollutants
    {
        [Key]
        public int SourceID { get; set; }

        public int? SectorID { get; set; }
        public virtual Sector? Sector { get; set; }

        public int NumberInCompany { get; set; }

        public string Name { get; set; } = string.Empty;

        public short? ModeNumber { get; set; }
        public virtual ModeOfIZAVWithNonStationaryEmissions? ModeOfIZAVWithNonStationaryEmissions { get; set; }

        public short WorkingHoursPerDay { get; set; }

        public short WorkingHoursPerYear { get; set; }

        public short AmountOfSOPWithOneNumber { get; set; }

        public int? GasCleanerID { get; set; }
        public virtual GasCleaner? GasCleaner { get; set; }

        public int? StationaryIZAVID { get; set; }
        public virtual StationaryIZAV? StationaryIZAV { get; set; }

        public virtual ICollection<SourceOfPollutants_Pollutant> SourcesOfPollutants_Pollutants { get; set; } = new List<SourceOfPollutants_Pollutant>();
    }
}
