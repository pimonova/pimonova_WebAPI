using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    [Table("InstrumentalEmissionMeasurings_Pollutants")]
    public class InstrumentalEmissionMeasuring_Pollutant
    {
        [Key]
        [Column(Order = 0)]
        public int? InstrumentalEmissionMeasuringID { get; set; }
        public virtual InstrumentalEmissionMeasuring? InstrumentalEmissionMeasuring { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? PollutantID { get; set; }
        public virtual Pollutant? Pollutant { get; set; }

        public float MassConcentration { get; set; }

        public float PollutantEmission { get; set; } // Выбросы ЗВ г/с

        public float MeanPollutantEmission { get; set; } // Выбросы ЗВ ср. г/с

        public float MaxPollutantEmission { get; set; } // Выбросы ЗВ max г/с

        public string MeasuringMethod { get; set; } = string.Empty;

    }
}
