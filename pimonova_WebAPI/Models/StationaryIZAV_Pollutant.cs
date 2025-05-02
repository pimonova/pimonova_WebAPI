using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    public class StationaryIZAV_Pollutant
    {
        [Key]
        [Column(Order = 0)]
        public int? StationaryIZAVID { get; set; }
        public virtual StationaryIZAV? StationaryIZAV { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? PollutantCode { get; set; }
        public virtual Pollutant? Pollutant { get; set; }

        public float PollutantConcentration { get; set; }

        public float PollutantEmissionPower { get; set; }

        public float GrossPollutantEmissionTonsPerYear { get; set; }

        public float TotalPollutantEmissionTonsPerPeriod { get; set; }
    }
}
