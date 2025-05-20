using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    [Table("StationaryIZAVs_Pollutants")]
    public class StationaryIZAV_Pollutant
    {
        [Key]
        [Column(Order = 0)]
        public int? StationaryIZAVID { get; set; }
        public virtual StationaryIZAV? StationaryIZAV { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? PollutantID { get; set; }
        public virtual Pollutant? Pollutant { get; set; }

        public float PollutantConcentration { get; set; } // Концентрация ЗВ, мг/м3

        public float PollutantEmissionPower { get; set; } // Мощность выброса, г/с

        public float GrossPollutantEmissionTonsPerYear { get; set; } // Суммарные годовые (валовые) выбросы режима, т/г

        public float TotalPollutantEmissionTonsPerPeriod { get; set; } // Итого за год выброс вещества источником, т/г
    }
}
