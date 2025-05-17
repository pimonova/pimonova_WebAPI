using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.DTOs.ModeOfIZAVWithNonStationaryEmissions;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class ModeOfIZAVWithNonStationaryEmissionsMappers
    {
        public static ModeOfIZAVWithNonStationaryEmissionsDTO ToModeOfIZAVWithNonStationaryEmissionsDTO(this ModeOfIZAVWithNonStationaryEmissions ModeOfIZAVWithNonStationaryEmissionsModel)
        {
            return new ModeOfIZAVWithNonStationaryEmissionsDTO
            {
                ModeID = ModeOfIZAVWithNonStationaryEmissionsModel.ModeID,
                ModeDescription = ModeOfIZAVWithNonStationaryEmissionsModel.ModeDescription,
                TimeOfWorking = ModeOfIZAVWithNonStationaryEmissionsModel.TimeOfWorking,
                ModeNumberInCompany = ModeOfIZAVWithNonStationaryEmissionsModel.ModeNumberInCompany,
            };
        }

        public static ModeOfIZAVWithNonStationaryEmissions ToModeOfIZAVWithNonStationaryEmissionsFromCreateOrUpdateDTO(this CreateOrUpdateModeOfIZAVWithNonStationaryEmissionsRequestDTO ModeOfIZAVWithNonStationaryEmissionsDTO)
        {
            return new ModeOfIZAVWithNonStationaryEmissions
            {
                ModeDescription = ModeOfIZAVWithNonStationaryEmissionsDTO.ModeDescription,
                TimeOfWorking = ModeOfIZAVWithNonStationaryEmissionsDTO.TimeOfWorking,
                ModeNumberInCompany = ModeOfIZAVWithNonStationaryEmissionsDTO.ModeNumberInCompany,
            };
        }
    }
}
