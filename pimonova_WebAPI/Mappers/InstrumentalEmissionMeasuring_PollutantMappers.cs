using pimonova_WebAPI.DTOs;
using pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuring_Pollutant;
using pimonova_WebAPI.DTOs.SourceOfPollutants_Pollutant;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class InstrumentalEmissionMeasuring_PollutantMappers
    {
        public static InstrumentalEmissionMeasuring_PollutantDTO ToInstrumentalEmissionMeasuring_PollutantDTO(this InstrumentalEmissionMeasuring_Pollutant InstrumentalEmissionMeasuring_PollutantModel)
        {
            return new InstrumentalEmissionMeasuring_PollutantDTO
            {
                InstrumentalEmissionMeasuringID = InstrumentalEmissionMeasuring_PollutantModel.InstrumentalEmissionMeasuringID,
                PollutantID = InstrumentalEmissionMeasuring_PollutantModel.PollutantID,
                MassConcentration = InstrumentalEmissionMeasuring_PollutantModel.MassConcentration,
                PollutantEmission = InstrumentalEmissionMeasuring_PollutantModel.PollutantEmission,
                MeanPollutantEmission = InstrumentalEmissionMeasuring_PollutantModel.MeanPollutantEmission,
                MaxPollutantEmission = InstrumentalEmissionMeasuring_PollutantModel.MaxPollutantEmission,
                MeasuringMethod = InstrumentalEmissionMeasuring_PollutantModel.MeasuringMethod,
            };
        }

        public static InstrumentalEmissionMeasuring_Pollutant ToInstrumentalEmissionMeasuring_PollutantFromCreateDTO(this CreateInstrumentalEmissionMeasuring_PollutantRequestDTO InstrumentalEmissionMeasuring_PollutantDTO, int InstrumentalEmissionMeasuringId, int PollutantId)
        {
            return new InstrumentalEmissionMeasuring_Pollutant
            {
                InstrumentalEmissionMeasuringID = InstrumentalEmissionMeasuringId,
                PollutantID = PollutantId,
                MassConcentration = InstrumentalEmissionMeasuring_PollutantDTO.MassConcentration,
                PollutantEmission = InstrumentalEmissionMeasuring_PollutantDTO.PollutantEmission,
                MeanPollutantEmission = InstrumentalEmissionMeasuring_PollutantDTO.MeanPollutantEmission,
                MaxPollutantEmission = InstrumentalEmissionMeasuring_PollutantDTO.MaxPollutantEmission,
                MeasuringMethod = InstrumentalEmissionMeasuring_PollutantDTO.MeasuringMethod,
            };
        }

        public static InstrumentalEmissionMeasuring_Pollutant ToInstrumentalEmissionMeasuring_PollutantFromUpdateDTO(this UpdateInstrumentalEmissionMeasuring_PollutantRequestDTO InstrumentalEmissionMeasuring_PollutantDTO)
        {
            return new InstrumentalEmissionMeasuring_Pollutant
            {
                InstrumentalEmissionMeasuringID = InstrumentalEmissionMeasuring_PollutantDTO.InstrumentalEmissionMeasuringID,
                PollutantID = InstrumentalEmissionMeasuring_PollutantDTO.PollutantID,
                MassConcentration = InstrumentalEmissionMeasuring_PollutantDTO.MassConcentration,
                PollutantEmission = InstrumentalEmissionMeasuring_PollutantDTO.PollutantEmission,
                MeanPollutantEmission = InstrumentalEmissionMeasuring_PollutantDTO.MeanPollutantEmission,
                MaxPollutantEmission = InstrumentalEmissionMeasuring_PollutantDTO.MaxPollutantEmission,
                MeasuringMethod = InstrumentalEmissionMeasuring_PollutantDTO.MeasuringMethod,
            };
        }
    }
}
