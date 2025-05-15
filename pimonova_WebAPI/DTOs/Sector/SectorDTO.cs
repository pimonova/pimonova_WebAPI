using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.Sector
{
    public class SectorDTO
    {
        [Key]
        [Required]
        public int SectorID { get; set; }

        [Required]
        public int? WorkshopID { get; set; }

        [Required]
        public int NumberInCompany { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
