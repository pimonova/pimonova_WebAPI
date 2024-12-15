using pimonova_WebAPI.DTOs.ObjectOfNEI;
using pimonova_WebAPI.DTOs.User;
using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Mappers
{
    public static class ObjectOfNEIMappers
    {
        public static ObjectOfNEIDTO ToObjectOfNEIDTO(this ObjectOfNEI ObjectOfNEIModel)
        {
            return new ObjectOfNEIDTO
            {
                ObjectOfNEIID = ObjectOfNEIModel.ObjectOfNEIID,
                CompanyID = ObjectOfNEIModel.CompanyID,
                Name = ObjectOfNEIModel.Name,
                LocationAddress = ObjectOfNEIModel.LocationAddress,
                Category = ObjectOfNEIModel.Category,
            };
        }

        public static ObjectOfNEI ToObjectOfNEIFromCreateDTO(this CreateObjectOfNEIRequestDTO ObjectOfNEIDTO, int CompanyId)
        {
            return new ObjectOfNEI
            {
                Name = ObjectOfNEIDTO.Name,
                LocationAddress = ObjectOfNEIDTO.LocationAddress,
                Category = ObjectOfNEIDTO.Category,
                CompanyID = CompanyId
            };
        }

        public static ObjectOfNEI ToObjectOfNEIFromUpdateDTO(this UpdateObjectOfNEIRequestDTO ObjectOfNEIDTO)
        {
            return new ObjectOfNEI
            {
                Name = ObjectOfNEIDTO.Name,
                LocationAddress = ObjectOfNEIDTO.LocationAddress,
                Category = ObjectOfNEIDTO.Category
            };
        }
    }
}
