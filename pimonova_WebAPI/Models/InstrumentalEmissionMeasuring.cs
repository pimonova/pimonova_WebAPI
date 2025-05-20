using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // Результаты инструментального определения показателей выбросов
    [Table("InstrumentalEmissionMeasurings")]
    public class InstrumentalEmissionMeasuring
    {
        [Key]
        public int ResultID { get; set; }

        [Column(TypeName = "date")]
        public DateTime Date { get; set; }

        public int? StationaryIZAVID { get; set; }
        public virtual StationaryIZAV? StationaryIZAV { get; set; }

        public float DiameterOfWasteGas { get; set; } // диаметр отходящих газов

        public float SpeedOfWasteGas { get; set; } // скорость отходящих газов

        public float VolumetricFlowRateOfWasteGasNC { get; set; } // Объёмный расход отходящих газов при нормальных условиях

        public float TrueVolumetricFlowRateOfWasteGas { get; set; } // Объёмный расход отходящих газов при фактических условиях

        public short TemperatureOfWasteGas { get; set; } // Температура отходящих газов

        public short PressureOfWasteGas { get; set; } // Давление отходящих газов

        public float WaterVaporConcentration { get; set; } // Концентрация паров воды

        public virtual ICollection<InstrumentalEmissionMeasuring_Pollutant> InstrumentalEmissionMeasurings_Pollutants { get; set; } = new List<InstrumentalEmissionMeasuring_Pollutant>();

    }
}
