using pimonova_WebAPI.DTOs.ResultOfGasCleanersInspection;
using pimonova_WebAPI.DTOs.Sector;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class ResultOfGasCleanersInspectionMappers
    {
        public static ResultOfGasCleanersInspectionDTO ToResultOfGasCleanersInspectionDTO(this ResultOfGasCleanersInspection ResultOfGasCleanersInspectionModel)
        {
            return new ResultOfGasCleanersInspectionDTO
            {
                ResultID = ResultOfGasCleanersInspectionModel.ResultID,
                GasCleanerID = ResultOfGasCleanersInspectionModel.GasCleanerID,
                ProjectCleaningDegree = ResultOfGasCleanersInspectionModel.ProjectCleaningDegree,
                TrueCleaningDegree = ResultOfGasCleanersInspectionModel.TrueCleaningDegree,
                ProjectProvisionCoeff = ResultOfGasCleanersInspectionModel.ProjectProvisionCoeff,
                TrueProvisionCoeff = ResultOfGasCleanersInspectionModel.TrueProvisionCoeff,
            };
        }

        public static ResultOfGasCleanersInspection ToResultOfGasCleanersInspectionFromCreateDTO(this CreateResultOfGasCleanersInspectionRequestDTO ResultOfGasCleanersInspectionDTO, int GasCleanerId)
        {
            return new ResultOfGasCleanersInspection
            {
                ProjectCleaningDegree = ResultOfGasCleanersInspectionDTO.ProjectCleaningDegree,
                TrueCleaningDegree = ResultOfGasCleanersInspectionDTO.TrueCleaningDegree,
                ProjectProvisionCoeff = ResultOfGasCleanersInspectionDTO.ProjectProvisionCoeff,
                TrueProvisionCoeff = ResultOfGasCleanersInspectionDTO.TrueProvisionCoeff,
                GasCleanerID = GasCleanerId,
            };
        }

        public static ResultOfGasCleanersInspection ToResultOfGasCleanersInspectionFromUpdateDTO(this UpdateResultOfGasCleanersInspectionRequestDTO ResultOfGasCleanersInspectionDTO)
        {
            return new ResultOfGasCleanersInspection
            {
                ProjectCleaningDegree = ResultOfGasCleanersInspectionDTO.ProjectCleaningDegree,
                TrueCleaningDegree = ResultOfGasCleanersInspectionDTO.TrueCleaningDegree,
                ProjectProvisionCoeff = ResultOfGasCleanersInspectionDTO.ProjectProvisionCoeff,
                TrueProvisionCoeff = ResultOfGasCleanersInspectionDTO.TrueProvisionCoeff,
            };
        }
    }
}
