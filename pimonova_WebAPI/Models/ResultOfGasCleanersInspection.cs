using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // Результаты обследования установок очистки газа и условий их эксплуатации
    public class ResultOfGasCleanersInspection
    {
        [Key]
        public int ResultID { get; set; }

        public int? GasCleanerID { get; set; }
        public virtual GasCleaner? GasCleaner { get; set; }

        public short ProjectCleaningDegree { get; set; }

        public short TrueCleaningDegree { get; set; }

        public float ProjectProvisionCoeff { get; set; }

        public float TrueProvisionCoeff { get; set; }

        public virtual ICollection<ResultOfGasCleanersInspection_Pollutant> ResultsOfGasCleanersInspection_Pollutants { get; set; } = new List<ResultOfGasCleanersInspection_Pollutant>();
    }
}
