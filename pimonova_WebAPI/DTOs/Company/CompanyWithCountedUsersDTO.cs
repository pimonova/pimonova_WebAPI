﻿using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.Company
{
    public class CompanyWithCountedUsersDTO
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string ShortName { get; set; } = string.Empty;

        [Required]
        public long INN { get; set; }

        [Required]
        public int CountedUsers { get; set; }
    }
}