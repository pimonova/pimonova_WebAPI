using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuring_Pollutant
{
    public class UpdateInstrumentalEmissionMeasuring_PollutantRequestDTO
    {
        [Key]
        [Column(Order = 0)]
        [Required]
        public int? InstrumentalEmissionMeasuringID { get; set; }

        [Key]
        [Column(Order = 1)]
        [Required]
        public int? PollutantID { get; set; }

        [Required]
        public float MassConcentration { get; set; }

        [Required]
        public float PollutantEmission { get; set; }

        [Required]
        public float MeanPollutantEmission { get; set; }

        [Required]
        public float MaxPollutantEmission { get; set; }

        [Required]
        public string MeasuringMethod { get; set; } = string.Empty;
    }
}
