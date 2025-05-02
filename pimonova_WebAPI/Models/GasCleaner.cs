using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    public class GasCleaner
    {
        [Key]
        public int GasCleanerID { get; set; }

        public int? SectorID { get; set; }
        public Sector? Sector { get; set; }

        public int NumberInCompany { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Type { get; set; } = string.Empty;

        public string Brand { get; set; } = string.Empty;

        //public int StationaryIZAVToOut { get; set; }

    }
}
