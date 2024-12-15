using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.ObjectOfNEI
{
    public class CreateObjectOfNEIRequestDTO
    {
        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LocationAddress { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty;

        [Required]
        public int? CompanyID { get; set; }
    }
}
