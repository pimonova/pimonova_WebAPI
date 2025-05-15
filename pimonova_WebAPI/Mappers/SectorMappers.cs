using pimonova_WebAPI.DTOs.ObjectOfNEI;
using pimonova_WebAPI.DTOs.Sector;
using pimonova_WebAPI.DTOs.Workshop;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class SectorMappers
    {
        public static SectorDTO ToSectorDTO(this Sector SectorModel)
        {
            return new SectorDTO
            {
                SectorID = SectorModel.SectorID,
                WorkshopID = SectorModel.WorkshopID,
                NumberInCompany = SectorModel.NumberInCompany,
                Name = SectorModel.Name,
            };
        }

        public static Sector ToSectorFromCreateDTO(this CreateSectorRequestDTO SectorDTO, int WorkshopId)
        {
            return new Sector
            {
                NumberInCompany = SectorDTO.NumberInCompany,
                Name = SectorDTO.Name,
                WorkshopID = WorkshopId
            };
        }

        public static Sector ToSectorFromUpdateDTO(this UpdateSectorRequestDTO SectorDTO)
        {
            return new Sector
            {
                NumberInCompany = SectorDTO.NumberInCompany,
                Name = SectorDTO.Name,
            };
        }
    }
}
