using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    public class Company
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Required]
        public string FullName { get; set; } = string.Empty;

        [Required]
        public string ShortName { get; set; } = string.Empty;

        [Required]
        public string RegAddress { get; set; } = string.Empty; // юридический адрес

        [Required]
        public string CurrAddress { get; set; } = string.Empty; // фактический адрес

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
        public string LineOfWork { get; set; } = string.Empty; // вид и род деятельности

        public virtual ICollection<User> Users { get; set; } = new List<User>();

        public virtual ICollection<ObjectOfNEI> ObjectOfNEI { get; set; } = new List<ObjectOfNEI>();
    }
}
