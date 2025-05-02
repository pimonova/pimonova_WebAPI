using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
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
