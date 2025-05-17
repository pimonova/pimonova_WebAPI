using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuring
{
    public class InstrumentalEmissionMeasuringDTO
    {
        [Key]
        [Required]
        public int ResultID { get; set; }

        [Required]
        public int? StationaryIZAVID { get; set; }

        [Required]
        public float DiameterOfWasteGas { get; set; }

        [Required]
        public float SpeedOfWasteGas { get; set; }

        [Required]
        public float VolumetricFlowRateOfWasteGasNC { get; set; }

        [Required]
        public float TrueVolumetricFlowRateOfWasteGas { get; set; }

        [Required]
        public short TemperatureOfWasteGas { get; set; }

        [Required]
        public short PressureOfWasteGas { get; set; }

        [Required]
        public float WaterVaporConcentration { get; set; }
    }
}
