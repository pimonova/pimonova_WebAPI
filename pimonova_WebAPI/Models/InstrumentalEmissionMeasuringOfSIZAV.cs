using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // Результаты инструментального определения показателей выбросов
    [Table("InstrumentalEmissionMeasuringsOfSIZAV")]
    public class InstrumentalEmissionMeasuringOfSIZAV
    {
        [Key]
        public int ResultID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? StationaryIZAVID { get; set; }
        public virtual StationaryIZAV? StationaryIZAV { get; set; }

        public float DiameterOfWasteGas { get; set; }

        public float SpeedOfWasteGas { get; set; }

        public float VolumetricFlowRateOfWasteGasNC { get; set; }

        public float TrueVolumetricFlowRateOfWasteGas { get; set; }

        public short TemperatureOfWasteGas { get; set; }

        public short PressureOfWasteGas { get; set; }

        public float WaterVaporConcentration { get; set; }

        public virtual ICollection<InstrumentalEmissionMeasuringOfSIZAV_Pollutant> InstrumentalEmissionMeasuringsOfSIZAV_Pollutants { get; set; } = new List<InstrumentalEmissionMeasuringOfSIZAV_Pollutant>();

    }
}
