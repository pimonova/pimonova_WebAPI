using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    [Table("Companies")]
    public class Company
    {
        [Key]
        public int CompanyID { get; set; }

        public string FullName { get; set; } = string.Empty;

        public string ShortName { get; set; } = string.Empty;

        public string RegAddress { get; set; } = string.Empty; // юридический адрес

        public string CurrAddress { get; set; } = string.Empty; // фактический адрес

        public string PhoneNumber { get; set; } = string.Empty;

        public long INN { get; set; }

        public int KPP { get; set; }

        public long OGRN { get; set; }

        public string Director { get; set; } = string.Empty;

        public string LineOfWork { get; set; } = string.Empty; // вид и род деятельности

        public virtual ICollection<User> Users { get; set; } = new List<User>();

        public virtual ICollection<ObjectOfNEI> ObjectOfNEI { get; set; } = new List<ObjectOfNEI>();
    }
}
