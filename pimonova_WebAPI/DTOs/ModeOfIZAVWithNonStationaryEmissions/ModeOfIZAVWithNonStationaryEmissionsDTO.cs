using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.ModeOfIZAVWithNonStationaryEmissions
{
    public class ModeOfIZAVWithNonStationaryEmissionsDTO
    {
        [Key]
        [Required]
        public int ModeID { get; set; }

        [Required]
        public string ModeDescription { get; set; } = string.Empty;

        [Required]
        public short TimeOfWorking { get; set; }

        [Required]
        public short ModeNumberInCompany { get; set; }
    }
}
