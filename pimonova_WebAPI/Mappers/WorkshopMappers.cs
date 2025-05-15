using pimonova_WebAPI.DTOs.ObjectOfNEI;
using pimonova_WebAPI.DTOs.Workshop;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class WorkshopMappers
    {
        public static WorkshopDTO ToWorkshopDTO(this Workshop WorkshopModel)
        {
            return new WorkshopDTO
            {
                WorkshopID = WorkshopModel.WorkshopID,
                ObjectOfNEIID = WorkshopModel.ObjectOfNEIID,
                NumberInCompany = WorkshopModel.NumberInCompany,
                Name = WorkshopModel.Name,
            };
        }

        public static Workshop ToWorkshopFromCreateDTO(this CreateWorkshopRequestDTO WorkshopDTO, int ObjectOfNEIId)
        {
            return new Workshop
            {
                NumberInCompany = WorkshopDTO.NumberInCompany,
                Name = WorkshopDTO.Name,
                ObjectOfNEIID = ObjectOfNEIId
            };
        }

        public static Workshop ToWorkshopFromUpdateDTO(this UpdateWorkshopRequestDTO WorkshopDTO)
        {
            return new Workshop
            {
                NumberInCompany = WorkshopDTO.NumberInCompany,
                Name = WorkshopDTO.Name,
            };
        }
    }
}
