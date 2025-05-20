using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    [Table("SourcesOfPollutants_Pollutants")]
    public class SourceOfPollutants_Pollutant
    {
        [Key]
        [Column(Order = 0)]
        public int? SourceOfPollutantsID { get; set; }
        public virtual SourceOfPollutants? SourceOfPollutants { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? PollutantID { get; set; }
        public virtual Pollutant? Pollutant { get; set; }

        public float PollutantAmountGramsPerSecond { get; set; } // Кол-во ЗВ, отходящих от ИВ при учете нестационарности, г/с

        public float PollutantAmountTonsPerYear { get; set; } // Кол-во ЗВ, отходящих от ИВ при учете нестационарности, т/г

        public float TotalPollutantAmountTonsPerYear { get; set; } // Кол-во ЗВ, отходящих от ИВ всего, т/г
    }
}
