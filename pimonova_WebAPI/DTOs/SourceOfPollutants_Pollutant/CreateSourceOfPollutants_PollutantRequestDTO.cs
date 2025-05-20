using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.SourceOfPollutants_Pollutant
{
    public class CreateSourceOfPollutants_PollutantRequestDTO
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int? SourceOfPollutantsID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        public int? PollutantID { get; set; }

        [Required]
        public float PollutantAmountGramsPerSecond { get; set; }

        [Required]
        public float PollutantAmountTonsPerYear { get; set; }

        [Required]
        public float TotalPollutantAmountTonsPerYear { get; set; }
    }
}
