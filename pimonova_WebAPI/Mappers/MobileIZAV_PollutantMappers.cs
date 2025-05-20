using pimonova_WebAPI.DTOs.MobileIZAV_Pollutant;
using pimonova_WebAPI.DTOs.ResultOfGasCleanersInspection_Pollutant;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class MobileIZAV_PollutantMAppers
    {
        public static MobileIZAV_PollutantDTO ToMobileIZAV_PollutantDTO(this MobileIZAV_Pollutant MobileIZAV_PollutantModel)
        {
            return new MobileIZAV_PollutantDTO
            {

                MobileIZAVID = MobileIZAV_PollutantModel.MobileIZAVID,
                PollutantID = MobileIZAV_PollutantModel.PollutantID,
                MeanPollutantEmission = MobileIZAV_PollutantModel.MeanPollutantEmission,
                MaxPollutantEmission = MobileIZAV_PollutantModel.MaxPollutantEmission,
                MeasuringMethod = MobileIZAV_PollutantModel.MeasuringMethod,
            };
        }

        public static MobileIZAV_Pollutant ToMobileIZAV_PollutantFromCreateDTO(this CreateMobileIZAV_PollutantRequestDTO MobileIZAV_PollutantDTO, int MobileIZAVId, int PollutantId)
        {
            return new MobileIZAV_Pollutant
            {
                MobileIZAVID = MobileIZAVId,
                PollutantID = PollutantId,
                MeanPollutantEmission = MobileIZAV_PollutantDTO.MeanPollutantEmission,
                MaxPollutantEmission = MobileIZAV_PollutantDTO.MaxPollutantEmission,
                MeasuringMethod = MobileIZAV_PollutantDTO.MeasuringMethod,
            };
        }

        public static MobileIZAV_Pollutant ToMobileIZAV_PollutantFromUpdateDTO(this UpdateMobileIZAV_PollutantRequestDTO MobileIZAV_PollutantDTO)
        {
            return new MobileIZAV_Pollutant
            {
                MobileIZAVID = MobileIZAV_PollutantDTO.MobileIZAVID,
                PollutantID = MobileIZAV_PollutantDTO.PollutantID,
                MeanPollutantEmission = MobileIZAV_PollutantDTO.MeanPollutantEmission,
                MaxPollutantEmission = MobileIZAV_PollutantDTO.MaxPollutantEmission,
                MeasuringMethod = MobileIZAV_PollutantDTO.MeasuringMethod,
            };
        }
    }
}
