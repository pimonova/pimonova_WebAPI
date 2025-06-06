﻿using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.User
{
    public class CreateUserRequestDTO
    {
        [Required]
        [MinLength(1, ErrorMessage = "Name must be at least 1 character")]
        public string Name { get; set; } = string.Empty;

        [Required]
        [MinLength(1, ErrorMessage = "Surname must be at least 1 character")]
        public string Surname { get; set; } = string.Empty;

        [Required]
        [EmailAddress]
        public string Email { get; set; } = string.Empty;

        //[Required]
        //public string Role { get; set; } = string.Empty;

        [Required]
        [MinLength(2, ErrorMessage = "Position must be at least 2 characters")]
        [MaxLength(200, ErrorMessage = "Position must be less than 200 characters")]
        public string Position { get; set; } = string.Empty;

        //[Required]
        //public int? CompanyID { get; set; }

        [Required]
        [MinLength(2, ErrorMessage = "Login must be at least 4 characters")]
        [MaxLength(20, ErrorMessage = "Login must be less than 20 characters")]
        public string Login { get; set; } = string.Empty;

        [Required]
        [MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
        [MaxLength(16, ErrorMessage = "Password must be less than 16 characters")]
        public string Password { get; set; } = string.Empty;

    }
}
