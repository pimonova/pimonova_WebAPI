using pimonova_WebAPI.DTOs.GasCleaner;
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
    }
}
