using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pimonova_WebAPI.Models
{
    // Передвижные ИЗАВ
    [Table("MobileIZAVs")]
    public class MobileIZAV
    {
        [Key]
        public int MobileIZAVID { get; set; }

        public int? SectorID { get; set; }
        public virtual Sector? Sector { get; set; }

        public string Name { get; set; } = string.Empty;

        public int NumberInCompany { get; set; }

        public short AmountOfIZAVWithOneNumber { get; set; }

        public short Speed { get; set; }

        public string Fuel { get; set; } = string.Empty;

        public short WorkingHoursPerSeason { get; set; }

        public short WorkingHoursPerYear { get; set; }

        public virtual ICollection<MobileIZAV_Pollutant> MobileIZAVs_Pollutants { get; set; } = new List<MobileIZAV_Pollutant>();
    }
}
