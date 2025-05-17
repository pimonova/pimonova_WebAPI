using pimonova_WebAPI.DTOs.GasCleaner;
using pimonova_WebAPI.DTOs.MobileIZAV;
using pimonova_WebAPI.DTOs.Sector;
using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Mappers
{
    public static class GasCleanerMappers
    {
        public static GasCleanerDTO ToGasCleanerDTO(this GasCleaner GasCleanerModel)
        {
            return new GasCleanerDTO
            {
                GasCleanerID = GasCleanerModel.GasCleanerID,
                SectorID = GasCleanerModel.SectorID,
                NumberInCompany = GasCleanerModel.NumberInCompany,
                Name = GasCleanerModel.Name,
                Type = GasCleanerModel.Type,
                Brand = GasCleanerModel.Brand,
                StationaryIZAVToOut = GasCleanerModel.StationaryIZAVToOut,
            };
        }

        public static GasCleaner ToGasCleanerFromCreateDTO(this CreateGasCleanerRequestDTO GasCleanerDTO)
        {
            return new GasCleaner
            {
                SectorID = GasCleanerDTO.SectorID,
                NumberInCompany = GasCleanerDTO.NumberInCompany,
                Name = GasCleanerDTO.Name,
                Type = GasCleanerDTO.Type,
                Brand = GasCleanerDTO.Brand,
                StationaryIZAVToOut = GasCleanerDTO.StationaryIZAVToOut,
            };
        }

        public static GasCleaner ToGasCleanerFromUpdateDTO(this UpdateGasCleanerRequestDTO GasCleanerDTO)
        {
            return new GasCleaner
            {
                SectorID = GasCleanerDTO.SectorID,
                NumberInCompany = GasCleanerDTO.NumberInCompany,
                Name = GasCleanerDTO.Name,
                Type = GasCleanerDTO.Type,
                Brand = GasCleanerDTO.Brand,
                StationaryIZAVToOut = GasCleanerDTO.StationaryIZAVToOut,
            };
        }
    }
}
