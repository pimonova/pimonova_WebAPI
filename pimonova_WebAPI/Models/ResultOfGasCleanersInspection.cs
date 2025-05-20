using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pimonova_WebAPI.Models
{
    // Результаты обследования установок очистки газа и условий их эксплуатации
    [Table("ResultsOfGasCleanersInspection")]
    public class ResultOfGasCleanersInspection
    {
        [Key]
        public int ResultID { get; set; }

        public int? GasCleanerID { get; set; }
        public virtual GasCleaner? GasCleaner { get; set; }

        public short ProjectCleaningDegree { get; set; } // Проектная степень очистки, %

        public short TrueCleaningDegree { get; set; } // Фактическая степень очистки, %

        public float ProjectProvisionCoeff { get; set; } // Нормативный коэффициент обеспеченности

        public float TrueProvisionCoeff { get; set; } // Фактических коэффициент обеспеченности

        public virtual ICollection<ResultOfGasCleanersInspection_Pollutant> ResultsOfGasCleanersInspection_Pollutants { get; set; } = new List<ResultOfGasCleanersInspection_Pollutant>();
    }
}
