using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    public class SourceOfPollutants_Pollutant
    {
        [Key]
        [Column(Order = 0)]
        public int SourceOfPollutantsID { get; set; }
        public virtual SourceOfPollutants? SourcesOfPollutant { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? PollutantCode { get; set; }
        public virtual Pollutant? Pollutant { get; set; }

        public float PollutantAmountGramsPerSecond { get; set; }

        public float PollutantAmountTonsPerYear { get; set; }

        public float TotalPollutantAmountTonsPerYear { get; set; }
    }
}
