using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // цех
    [Table("Workshops")]
    public class Workshop
    {
        [Key]
        public int WorkshopID { get; set; }

        public int? ObjectOfNEIID { get; set; }
        public ObjectOfNEI? ObjectOfNEI { get; set; }

        public int NumberInCompany { get; set; }

        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Sector> Sectors { get; set; } = new List<Sector>();
    }
}
