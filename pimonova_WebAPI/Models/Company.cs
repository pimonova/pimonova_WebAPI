using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    public class Company
    {
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

        [Key]
        [Required]
        public int INN { get; set; }

        [Required]
        public int KPP { get; set; }

        [Required]
        public int OGRN { get; set; }

        [Required]
        public string Director { get; set; } = string.Empty;

        [Required]
        public string LineOfWork { get; set; } = string.Empty; // вид и род деятельности

        public virtual ICollection<User> Users { get; set; } = new List<User>();

        public virtual ICollection<ObjectOfNEI> ObjectOfNEI { get; set; } = new List<ObjectOfNEI>();
    }
}
