using pimonova_WebAPI.DTOs.MobileIZAV_Pollutant;
using pimonova_WebAPI.DTOs.SourceOfPollutants_Pollutant;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class SourceOfPollutants_PollutantMAppers
    {
        public static SourceOfPollutants_PollutantDTO ToSourceOfPollutants_PollutantDTO(this SourceOfPollutants_Pollutant SourceOfPollutants_PollutantModel)
        {
            return new SourceOfPollutants_PollutantDTO
            {

                SourceOfPollutantsID = SourceOfPollutants_PollutantModel.SourceOfPollutantsID,
                PollutantID = SourceOfPollutants_PollutantModel.PollutantID,
                PollutantAmountGramsPerSecond = SourceOfPollutants_PollutantModel.PollutantAmountGramsPerSecond,
                PollutantAmountTonsPerYear = SourceOfPollutants_PollutantModel.PollutantAmountTonsPerYear,
                TotalPollutantAmountTonsPerYear = SourceOfPollutants_PollutantModel.TotalPollutantAmountTonsPerYear,
            };
        }

        public static SourceOfPollutants_Pollutant ToSourceOfPollutants_PollutantFromCreateDTO(this CreateSourceOfPollutants_PollutantRequestDTO SourceOfPollutants_PollutantDTO, int SourceOfPollutantsId, int PollutantId)
        {
            return new SourceOfPollutants_Pollutant
            {
                SourceOfPollutantsID = SourceOfPollutantsId,
                PollutantID = PollutantId,
                PollutantAmountGramsPerSecond = SourceOfPollutants_PollutantDTO.PollutantAmountGramsPerSecond,
                PollutantAmountTonsPerYear = SourceOfPollutants_PollutantDTO.PollutantAmountTonsPerYear,
                TotalPollutantAmountTonsPerYear = SourceOfPollutants_PollutantDTO.TotalPollutantAmountTonsPerYear,
            };
        }

        public static SourceOfPollutants_Pollutant ToSourceOfPollutants_PollutantFromUpdateDTO(this UpdateSourceOfPollutants_PollutantRequestDTO SourceOfPollutants_PollutantDTO)
        {
            return new SourceOfPollutants_Pollutant
            {
                SourceOfPollutantsID = SourceOfPollutants_PollutantDTO.SourceOfPollutantsID,
                PollutantID = SourceOfPollutants_PollutantDTO.PollutantID,
                PollutantAmountGramsPerSecond = SourceOfPollutants_PollutantDTO.PollutantAmountGramsPerSecond,
                PollutantAmountTonsPerYear = SourceOfPollutants_PollutantDTO.PollutantAmountTonsPerYear,
                TotalPollutantAmountTonsPerYear = SourceOfPollutants_PollutantDTO.TotalPollutantAmountTonsPerYear,
            };
        }
    }
}
