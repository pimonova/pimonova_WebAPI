using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.Company
{
    public class CreateCompanyRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Full name must be at least 3 characters")]
        [MaxLength(200, ErrorMessage = "Full name must be less than 200 characters")]
        public string FullName { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Short name must be at least 3 characters")]
        [MaxLength(150, ErrorMessage = "Short name must be less than 150 characters")]
        public string ShortName { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Registered address must be at least 5 characters")]
        [MaxLength(250, ErrorMessage = "Registered address must be less than 250 characters")]
        public string RegAddress { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Current address must be at least 5 characters")]
        [MaxLength(250, ErrorMessage = "Current address must be less than 250 characters")]
        public string CurrAddress { get; set; } = string.Empty;

        [Required]
        [MinLength(4, ErrorMessage = "PhoneNumber must be at least 4 characters")]
        [MaxLength(23, ErrorMessage = "PhoneNumber must be less than 23 characters")]
        [Phone]
        public string PhoneNumber { get; set; } = string.Empty;

        [Required]
        public long INN { get; set; }

        [Required]
        public int KPP { get; set; }

        [Required]
        public long OGRN { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Director's name must be at least 2 characters")]
        public string Director { get; set; } = string.Empty;

        [Required]
        [MinLength(4, ErrorMessage = "Line of work must be at least 4 characters")]
        [MaxLength(200, ErrorMessage = "Line of work must be less than 200 characters")]
        public string LineOfWork { get; set; } = string.Empty;
    }
}
