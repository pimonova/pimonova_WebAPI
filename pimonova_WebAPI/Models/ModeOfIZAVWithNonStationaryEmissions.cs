using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace pimonova_WebAPI.Models
{
    [Table("ModesOfIZAVWithNonStationaryEmissions")]
    public class ModeOfIZAVWithNonStationaryEmissions
    {
        [Key]
        public int ModeID { get; set; }

        public string ModeDescription { get; set; } = string.Empty;

        public short TimeOfWorking { get; set; }

        public short ModeNumberInCompany { get; set; }

        public virtual ICollection<SourceOfPollutants> SourcesOfPollutants { get; set; } = new List<SourceOfPollutants>();
    }
}
