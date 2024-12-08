using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // цех
    public class Workshop
    {
        [Key]
        [Required]
        public int WorkshopID { get; set; }

        [Required]
        public int? ObjectOfNEIID { get; set; }
        public ObjectOfNEI? ObjectOfNEI { get; set; }

        [Required]
        public int NumberInCompany { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        public virtual ICollection<Sector> Sectors { get; set; } = new List<Sector>();
    }
}
