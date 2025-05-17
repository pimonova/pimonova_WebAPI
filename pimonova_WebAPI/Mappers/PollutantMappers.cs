using pimonova_WebAPI.DTOs.ModeOfIZAVWithNonStationaryEmissions;
using pimonova_WebAPI.DTOs.Pollutant;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class PollutantMappers
    {
        public static PollutantDTO ToPollutantDTO(this Pollutant PollutantModel)
        {
            return new PollutantDTO
            {
                PollutantID = PollutantModel.PollutantID,
                Code = PollutantModel.Code,
                Name = PollutantModel.Name,
            };
        }

        public static Pollutant ToPollutantFromCreateOrUpdateDTO(this CreateOrUpdatePollutantRequestDTO PollutantDTO)
        {
            return new Pollutant
            {
                Code = PollutantDTO.Code,
                Name = PollutantDTO.Name,
            };
        }
    }
}
