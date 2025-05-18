using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.DTOs.ResultOfGasCleanersInspection
{
    public class CreateResultOfGasCleanersInspectionRequestDTO
    {
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
