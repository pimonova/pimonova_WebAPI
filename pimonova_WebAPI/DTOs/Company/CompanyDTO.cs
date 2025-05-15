using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;
using pimonova_WebAPI.DTOs.ObjectOfNEI;
using pimonova_WebAPI.DTOs.User;

namespace pimonova_WebAPI.DTOs.Company
{
    public class CompanyDTO
    {
        [Key]
        [Required]
        public int Id { get; set; }

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

        //public List<ObjectOfNEIDTO> ObjectsOfNEI { get; set; }

        //public List<UserDTO> Users { get; set; }
    }
}
