using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // площадка в цехе
    public class Sector
    {
        [Key]
        //[Required]
        public int SectorID { get; set; }

        //[Required]
        public int? WorkshopID { get; set; }
        public Workshop? Workshop { get; set; }

        //[Required]
        public int NumberInCompany { get; set; }

        //[Required]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<GasCleaner> GasCleaners { get; set; } = new List<GasCleaner>();

        public virtual ICollection<MobileIZAV> MobileIZAVs { get; set; } = new List<MobileIZAV>();

        public virtual ICollection<SourceOfPollutants> SourcesOfPollutants { get; set; } = new List<SourceOfPollutants>();

        public virtual ICollection<StationaryIZAV> StationaryIZAVs { get; set; } = new List<StationaryIZAV>();
    }
}
