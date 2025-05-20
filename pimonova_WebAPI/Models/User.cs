using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pimonova_WebAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        public int UserID { get; set; }

        public string Name { get; set; } = string.Empty;

        public string Surname { get; set; } = string.Empty;

        public string Email { get; set; } = string.Empty;

        public string Position { get; set; } = string.Empty; // должность в компании

        public int? CompanyID { get; set; }
        public Company? Company { get; set; }

        public string Login { get; set; } = string.Empty;

        public string Role => CompanyID == 1? "Admin" : "User"; // права доступа (в приложении)

        public string Password { get; set; } = string.Empty;

        public bool IsAdmin => Role == "Admin";
    }
}
