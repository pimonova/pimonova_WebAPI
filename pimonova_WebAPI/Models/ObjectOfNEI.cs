using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // Object of negative environmental impact - объект негативного воздействия на окружающую среду (ОНВ)
    [Table("ObjectsOfNEI")]
    public class ObjectOfNEI
    {
        [Key]
        public int ObjectOfNEIID { get; set; }

        public int? CompanyID { get; set; }
        // Convention
        // NAvigation property - EF будет искать по коду совпадения и создавать отношения
        public Company? Company { get; set; }

        public string Name { get; set; } = string.Empty;

        public string LocationAddress { get; set; } = string.Empty;

        public string Category { get; set; } = string.Empty; // категория объекта НВОС

        public virtual ICollection<Workshop> Workshops { get; set; } = new List<Workshop>();
    }
}
