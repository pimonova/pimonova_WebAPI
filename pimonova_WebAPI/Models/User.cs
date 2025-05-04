using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pimonova_WebAPI.Models
{
    [Table("Users")]
    public class User
    {
        [Key]
        //[Required]
        public int UserID { get; set; }

        //[Required]
        public string Name { get; set; } = string.Empty;

        //[Required]
        public string Surname { get; set; } = string.Empty;

        //[Required]
        public string Email { get; set; } = string.Empty;

        //[Required]
        public string Position { get; set; } = string.Empty; // должность в компании

        //[Required]
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }

        //[Required]
        public string Login { get; set; } = string.Empty;

        //[Required]
        public string Role => CompanyID == 1? "Admin" : "User"; // права доступа (в приложении)

        //[Required]
        public string Password { get; set; } = string.Empty;

        public bool IsAdmin => Role == "Admin";
    }
}
