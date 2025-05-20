using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.ResultOfGasCleanersInspection_Pollutant
{
    public class ResultOfGasCleanersInspection_PollutantDTO
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int? ResultOfGasCleanersInspectionID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        public int? PollutantID { get; set; }
    }
}
