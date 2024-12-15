using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    // Object of negative environmental impact - объект негативного воздействия на окружающую среду (ОНВ)
    public class ObjectOfNEI
    {
        [Key]
        [Required]
        public int ObjectOfNEIID { get; set; }

        [Required]
        public int? CompanyID { get; set; }
        public Company? Company { get; set; }

        [Required]
        public string Name { get; set; } = string.Empty;

        [Required]
        public string LocationAddress { get; set; } = string.Empty;

        [Required]
        public string Category { get; set; } = string.Empty; // категория объекта НВОС

        public virtual ICollection<Workshop> Workshops { get; set; } = new List<Workshop>();
    }
}
