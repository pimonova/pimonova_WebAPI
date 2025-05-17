using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // Загрязняющее вещество (ЗВ)
    [Table("Pollutants")]
    public class Pollutant
    {
        [Key]
        public int PollutantID { get; set; }

        public string Code { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<ResultOfGasCleanersInspection_Pollutant> ResultsOfGasCleanersInspection_Pollutants { get; set; } = new List<ResultOfGasCleanersInspection_Pollutant>();
        
        public virtual ICollection<MobileIZAV_Pollutant> MobileIZAVs_Pollutants { get; set; } = new List<MobileIZAV_Pollutant>();
        
        public virtual ICollection<SourceOfPollutants_Pollutant> SourcesOfPollutants_Pollutants { get; set; } = new List<SourceOfPollutants_Pollutant>();
        
        public virtual ICollection<StationaryIZAV_Pollutant> StationaryIZAVs_Pollutants { get; set; } = new List<StationaryIZAV_Pollutant>();
        
        public virtual ICollection<InstrumentalEmissionMeasuring_Pollutant> InstrumentalEmissionMeasurings_Pollutants { get; set; } = new List<InstrumentalEmissionMeasuring_Pollutant>();

    }
}
