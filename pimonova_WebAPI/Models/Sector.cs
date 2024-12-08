using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // площадка в цехе
    public class Sector
    {
        [Key]
        [Required]
        public int SectorID { get; set; }

        [Required]
        public int? WorkshopID { get; set; }
        public Workshop? Workshop { get; set; }

        [Required]
        public int NumberInCompany { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
