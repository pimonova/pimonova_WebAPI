using pimonova_WebAPI.DTOs.ResultOfGasCleanersInspection_Pollutant;
using pimonova_WebAPI.DTOs.StationaryIZAV_Pollutant;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class ResultOfGasCleanersInspection_PollutantMAppers
    {
        public static ResultOfGasCleanersInspection_PollutantDTO ToResultOfGasCleanersInspection_PollutantDTO(this ResultOfGasCleanersInspection_Pollutant ResultOfGasCleanersInspection_PollutantModel)
        {
            return new ResultOfGasCleanersInspection_PollutantDTO
            {

                ResultOfGasCleanersInspectionID = ResultOfGasCleanersInspection_PollutantModel.ResultOfGasCleanersInspectionID,
                PollutantID = ResultOfGasCleanersInspection_PollutantModel.PollutantID,
            };
        }

        public static ResultOfGasCleanersInspection_Pollutant ToResultOfGasCleanersInspection_PollutantFromCreateDTO(this CreateResultOfGasCleanersInspection_PollutantRequestDTO ResultOfGasCleanersInspection_PollutantDTO, int ResultOfGasCleanersInspectionId, int PollutantId)
        {
            return new ResultOfGasCleanersInspection_Pollutant
            {
                ResultOfGasCleanersInspectionID = ResultOfGasCleanersInspectionId,
                PollutantID = PollutantId,
            };
        }

        public static ResultOfGasCleanersInspection_Pollutant ToResultOfGasCleanersInspection_PollutantFromUpdateDTO(this UpdateResultOfGasCleanersInspection_PollutantRequestDTO ResultOfGasCleanersInspection_PollutantDTO)
        {
            return new ResultOfGasCleanersInspection_Pollutant
            {
                ResultOfGasCleanersInspectionID = ResultOfGasCleanersInspection_PollutantDTO.ResultOfGasCleanersInspectionID,
                PollutantID = ResultOfGasCleanersInspection_PollutantDTO.PollutantID,
            };
        }
    }
}
