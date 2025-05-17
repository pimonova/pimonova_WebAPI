using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    [Table("ResultsOfGasCleanersInspection_Pollutants")]
    public class ResultOfGasCleanersInspection_Pollutant
    {
        [Key]
        [Column(Order = 0)]
        public int? ResultOfGasCleanersInspectionID { get; set; }
        public virtual ResultOfGasCleanersInspection? ResultOfGasCleanersInspection { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? PollutantID { get; set; }
        public virtual Pollutant? Pollutant { get; set; }
    }
}
