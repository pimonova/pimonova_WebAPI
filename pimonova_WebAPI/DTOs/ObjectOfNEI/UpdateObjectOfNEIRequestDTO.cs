using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.ObjectOfNEI
{
    public class UpdateObjectOfNEIRequestDTO
    {
        [Required]
        [MinLength(3, ErrorMessage = "Name must be at least 3 characters")]
        [MaxLength(200, ErrorMessage = "Name must be less than 200 characters")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(5, ErrorMessage = "Address must be at least 5 characters")]
        [MaxLength(250, ErrorMessage = "Address must be less than 250 characters")]
        public string LocationAddress { get; set; } = string.Empty;

        [Required]
        [MinLength(3, ErrorMessage = "Category must be at least 3 characters")]
        [MaxLength(50, ErrorMessage = "Category must be less than 50 characters")]
        public string Category { get; set; } = string.Empty;
    }
}
