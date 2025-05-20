using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.StationaryIZAV_Pollutant
{
    public class UpdateStationaryIZAV_PollutantRequestDTO
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int? StationaryIZAVID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        public int? PollutantID { get; set; }

        [Required]
        public float PollutantConcentration { get; set; }

        [Required]
        public float PollutantEmissionPower { get; set; }

        public float GrossPollutantEmissionTonsPerYear { get; set; }

        [Required]
        public float TotalPollutantEmissionTonsPerPeriod { get; set; }
    }
}
