using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.ResultOfGasCleanersInspection
{
    public class ResultOfGasCleanersInspectionDTO
    {
        [Key]
        [Required]
        public int ResultID { get; set; }

        [Required]
        public int? GasCleanerID { get; set; }

        [Required]
        public short ProjectCleaningDegree { get; set; }

        [Required]
        public short TrueCleaningDegree { get; set; }

        [Required]
        public float ProjectProvisionCoeff { get; set; }

        [Required]
        public float TrueProvisionCoeff { get; set; }
    }
}
