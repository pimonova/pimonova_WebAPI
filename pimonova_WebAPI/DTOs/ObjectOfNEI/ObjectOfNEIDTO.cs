using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.ObjectOfNEI
{
    public class ObjectOfNEIDTO
    {
        [Key]
        [Required]
        public int ObjectOfNEIID { get; set; }

        [Required]
        public int? CompanyID { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LocationAddress { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;
    }
}
