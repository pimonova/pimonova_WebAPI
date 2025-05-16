using pimonova_WebAPI.DTOs.GasCleaner;
using pimonova_WebAPI.DTOs.MobileIZAV;
using pimonova_WebAPI.DTOs.Sector;
using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Mappers
{
    public static class MobileIZAVMappers
    {
        public static MobileIZAVDTO ToMobileIZAVDTO(this MobileIZAV MobileIZAVModel)
        {
            return new MobileIZAVDTO
            {
                MobileIZAVID = MobileIZAVModel.MobileIZAVID,
                SectorID = MobileIZAVModel.SectorID,
                Name = MobileIZAVModel.Name,
                NumberInCompany = MobileIZAVModel.NumberInCompany,
                AmountOfIZAVWithOneNumber = MobileIZAVModel.AmountOfIZAVWithOneNumber,
                Speed = MobileIZAVModel.Speed,
                Fuel = MobileIZAVModel.Fuel,
                WorkingHoursPerSeason = MobileIZAVModel.WorkingHoursPerSeason,
                WorkingHoursPerYear = MobileIZAVModel.WorkingHoursPerYear,
            };
        }

        public static MobileIZAV ToMobileIZAVFromCreateDTO(this CreateMobileIZAVRequestDTO MobileIZAVDTO, int SectorId)
        {
            return new MobileIZAV
            {
                Name = MobileIZAVDTO.Name,
                NumberInCompany = MobileIZAVDTO.NumberInCompany,
                AmountOfIZAVWithOneNumber = MobileIZAVDTO.AmountOfIZAVWithOneNumber,
                Speed = MobileIZAVDTO.Speed,
                Fuel = MobileIZAVDTO.Fuel,
                WorkingHoursPerSeason = MobileIZAVDTO.WorkingHoursPerSeason,
                WorkingHoursPerYear = MobileIZAVDTO.WorkingHoursPerYear,
                SectorID = SectorId,
            };
        }

        public static MobileIZAV ToMobileIZAVFromUpdateDTO(this UpdateMobileIZAVRequestDTO MobileIZAVDTO)
        {
            return new MobileIZAV
            {
                Name = MobileIZAVDTO.Name,
                NumberInCompany = MobileIZAVDTO.NumberInCompany,
                AmountOfIZAVWithOneNumber = MobileIZAVDTO.AmountOfIZAVWithOneNumber,
                Speed = MobileIZAVDTO.Speed,
                Fuel = MobileIZAVDTO.Fuel,
                WorkingHoursPerSeason = MobileIZAVDTO.WorkingHoursPerSeason,
                WorkingHoursPerYear = MobileIZAVDTO.WorkingHoursPerYear,
            };
        }
    }
}
