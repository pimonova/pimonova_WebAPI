using pimonova_WebAPI.DTOs.GasCleaner;
using pimonova_WebAPI.DTOs.SourceOfPollutants;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class SourceOfPollutantsMappers
    {
        public static SourceOfPollutantsDTO ToSourceOfPollutantsDTO(this SourceOfPollutants SourceOfPollutantsModel)
        {
            return new SourceOfPollutantsDTO
            {
                SourceID = SourceOfPollutantsModel.SourceID,
                SectorID = SourceOfPollutantsModel.SectorID,
                NumberInCompany = SourceOfPollutantsModel.NumberInCompany,
                Name = SourceOfPollutantsModel.Name,
                ModeNumber = SourceOfPollutantsModel.ModeNumber,
                WorkingHoursPerDay = SourceOfPollutantsModel.WorkingHoursPerDay,
                WorkingHoursPerYear = SourceOfPollutantsModel.WorkingHoursPerYear,
                AmountOfSOPWithOneNumber = SourceOfPollutantsModel.AmountOfSOPWithOneNumber,
                GasCleanerID = SourceOfPollutantsModel.GasCleanerID,
                StationaryIZAVID = SourceOfPollutantsModel.StationaryIZAVID,
            };
        }

        public static SourceOfPollutants ToSourceOfPollutantsFromCreateDTO(this CreateSourceOfPollutantsRequestDTO SourceOfPollutantsDTO)
        {
            return new SourceOfPollutants
            {
                SectorID = SourceOfPollutantsDTO.SectorID,
                NumberInCompany = SourceOfPollutantsDTO.NumberInCompany,
                Name = SourceOfPollutantsDTO.Name,
                ModeNumber = SourceOfPollutantsDTO.ModeNumber,
                WorkingHoursPerDay = SourceOfPollutantsDTO.WorkingHoursPerDay,
                WorkingHoursPerYear = SourceOfPollutantsDTO.WorkingHoursPerYear,
                AmountOfSOPWithOneNumber = SourceOfPollutantsDTO.AmountOfSOPWithOneNumber,
                GasCleanerID = SourceOfPollutantsDTO.GasCleanerID,
                StationaryIZAVID = SourceOfPollutantsDTO.StationaryIZAVID,
            };
        }

        public static SourceOfPollutants ToSourceOfPollutantsFromUpdateDTO(this UpdateSourceOfPollutantsRequestDTO SourceOfPollutantsDTO)
        {
            return new SourceOfPollutants
            {
                SectorID = SourceOfPollutantsDTO.SectorID,
                NumberInCompany = SourceOfPollutantsDTO.NumberInCompany,
                Name = SourceOfPollutantsDTO.Name,
                ModeNumber = SourceOfPollutantsDTO.ModeNumber,
                WorkingHoursPerDay = SourceOfPollutantsDTO.WorkingHoursPerDay,
                WorkingHoursPerYear = SourceOfPollutantsDTO.WorkingHoursPerYear,
                AmountOfSOPWithOneNumber = SourceOfPollutantsDTO.AmountOfSOPWithOneNumber,
                GasCleanerID = SourceOfPollutantsDTO.GasCleanerID,
                StationaryIZAVID = SourceOfPollutantsDTO.StationaryIZAVID,
            };
        }
    }
}
