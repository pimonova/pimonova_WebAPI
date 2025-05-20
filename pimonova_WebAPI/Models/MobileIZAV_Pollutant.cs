using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    [Table("MobileIZAVs_Pollutants")]
    public class MobileIZAV_Pollutant
    {
        [Key]
        [Column(Order = 0)]
        public int? MobileIZAVID { get; set; }
        public virtual MobileIZAV? MobileIZAV { get; set; }

        [Key]
        [Column(Order = 1)]
        public int? PollutantID { get; set; }
        public virtual Pollutant? Pollutant { get; set; }

        public float MeanPollutantEmission { get; set; } // Выбросы ЗВ ср. г/с

        public float MaxPollutantEmission { get; set; } // Выбросы ЗВ max г/с

        public string MeasuringMethod { get; set; } = string.Empty;
    }
}
