using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // Загрязняющее вещество (ЗВ)
    public class Pollutant
    {
        [Key]
        public int Code { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<ResultOfGasCleanersInspection_Pollutant> ResultsOfGasCleanersInspection_Pollutants { get; set; } = new List<ResultOfGasCleanersInspection_Pollutant>();
        
        public virtual ICollection<MobileIZAV_Pollutant> MobileIZAVs_Pollutants { get; set; } = new List<MobileIZAV_Pollutant>();
        
        public virtual ICollection<SourceOfPollutants_Pollutant> SourcesOfPollutants_Pollutants { get; set; } = new List<SourceOfPollutants_Pollutant>();
        
        public virtual ICollection<StationaryIZAV_Pollutant> StationaryIZAVs_Pollutants { get; set; } = new List<StationaryIZAV_Pollutant>();
        
        public virtual ICollection<InstrumentalEmissionMeasuringOfSIZAV_Pollutant> InstrumentalEmissionMeasuringsOfSIZAV_Pollutants { get; set; } = new List<InstrumentalEmissionMeasuringOfSIZAV_Pollutant>();

    }
}
