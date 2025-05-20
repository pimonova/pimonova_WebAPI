using pimonova_WebAPI.DTOs.GasCleaner;
using pimonova_WebAPI.DTOs.StationaryIZAV_Pollutant;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class StationaryIZAV_PollutantMappers
    {
        public static StationaryIZAV_PollutantDTO ToStationaryIZAV_PollutantDTO(this StationaryIZAV_Pollutant StationaryIZAV_PollutantModel)
        {
            return new StationaryIZAV_PollutantDTO
            {
                
                StationaryIZAVID = StationaryIZAV_PollutantModel.StationaryIZAVID,
                PollutantID = StationaryIZAV_PollutantModel.PollutantID,
                PollutantConcentration = StationaryIZAV_PollutantModel.PollutantConcentration,
                PollutantEmissionPower = StationaryIZAV_PollutantModel.PollutantEmissionPower,
                GrossPollutantEmissionTonsPerYear = StationaryIZAV_PollutantModel.GrossPollutantEmissionTonsPerYear,
                TotalPollutantEmissionTonsPerPeriod = StationaryIZAV_PollutantModel.TotalPollutantEmissionTonsPerPeriod,
            };
        }

        public static StationaryIZAV_Pollutant ToStationaryIZAV_PollutantFromCreateDTO(this CreateStationaryIZAV_PollutantRequestDTO StationaryIZAV_PollutantDTO, int StationaryIZAVId, int PollutantId)
        {
            return new StationaryIZAV_Pollutant
            {
                StationaryIZAVID = StationaryIZAVId,
                PollutantID = PollutantId,
                PollutantConcentration = StationaryIZAV_PollutantDTO.PollutantConcentration,
                PollutantEmissionPower = StationaryIZAV_PollutantDTO.PollutantEmissionPower,
                GrossPollutantEmissionTonsPerYear = StationaryIZAV_PollutantDTO.GrossPollutantEmissionTonsPerYear,
                TotalPollutantEmissionTonsPerPeriod = StationaryIZAV_PollutantDTO.TotalPollutantEmissionTonsPerPeriod,
            };
        }

        public static StationaryIZAV_Pollutant ToStationaryIZAV_PollutantFromUpdateDTO(this UpdateStationaryIZAV_PollutantRequestDTO StationaryIZAV_PollutantDTO)
        {
            return new StationaryIZAV_Pollutant
            {
                StationaryIZAVID = StationaryIZAV_PollutantDTO.StationaryIZAVID,
                PollutantID = StationaryIZAV_PollutantDTO.PollutantID,
                PollutantConcentration = StationaryIZAV_PollutantDTO.PollutantConcentration,
                PollutantEmissionPower = StationaryIZAV_PollutantDTO.PollutantEmissionPower,
                GrossPollutantEmissionTonsPerYear = StationaryIZAV_PollutantDTO.GrossPollutantEmissionTonsPerYear,
                TotalPollutantEmissionTonsPerPeriod = StationaryIZAV_PollutantDTO.TotalPollutantEmissionTonsPerPeriod,
            };
        }
    }
}
