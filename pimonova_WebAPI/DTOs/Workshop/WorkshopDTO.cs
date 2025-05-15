using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.Workshop
{
    public class WorkshopDTO
    {
        [Key]
        [Required]
        public int WorkshopID { get; set; }

        [Required]
        public int? ObjectOfNEIID { get; set; }

        [Required]
        public int NumberInCompany { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;
    }
}
