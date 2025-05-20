using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.MobileIZAV_Pollutant
{
    public class MobileIZAV_PollutantDTO
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int? MobileIZAVID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        public int? PollutantID { get; set; }

        [Required]
        public float MeanPollutantEmission { get; set; }

        [Required]
        public float MaxPollutantEmission { get; set; }

        [Required]
        public string MeasuringMethod { get; set; } = string.Empty;
    }
}
