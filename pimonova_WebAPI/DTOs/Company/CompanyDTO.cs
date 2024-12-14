using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.Company
{
    public class CompanyDTO
    {
        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string ShortName { get; set; } = string.Empty;

        [Required]
        public string RegAddress { get; set; } = string.Empty;

        [Required]
        public string CurrAddress { get; set; } = string.Empty;

        [Required]
        public string PhoneNumber { get; set; } = string.Empty;

        [Key]
        [Required]
        public long INN { get; set; }

        [Required]
        public int KPP { get; set; }

        [Required]
        public long OGRN { get; set; }

        [Required]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string LineOfWork { get; set; } = string.Empty;
    }
}
