using pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuring;
using pimonova_WebAPI.DTOs.StationaryIZAV;
using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Mappers
{
    public static class InstrumentalEmissionMeasuringMappers
    {
        public static InstrumentalEmissionMeasuringDTO ToInstrumentalEmissionMeasuringDTO(this InstrumentalEmissionMeasuring InstrumentalEmissionMeasuringModel)
        {
            return new InstrumentalEmissionMeasuringDTO
            {
                ResultID = InstrumentalEmissionMeasuringModel.ResultID,
                StationaryIZAVID = InstrumentalEmissionMeasuringModel.StationaryIZAVID,
                DiameterOfWasteGas = InstrumentalEmissionMeasuringModel.DiameterOfWasteGas,
                SpeedOfWasteGas = InstrumentalEmissionMeasuringModel.SpeedOfWasteGas,
                VolumetricFlowRateOfWasteGasNC = InstrumentalEmissionMeasuringModel.VolumetricFlowRateOfWasteGasNC,
                TrueVolumetricFlowRateOfWasteGas = InstrumentalEmissionMeasuringModel.TrueVolumetricFlowRateOfWasteGas,
                TemperatureOfWasteGas = InstrumentalEmissionMeasuringModel.TemperatureOfWasteGas,
                PressureOfWasteGas = InstrumentalEmissionMeasuringModel.PressureOfWasteGas,
                WaterVaporConcentration = InstrumentalEmissionMeasuringModel.WaterVaporConcentration,
            };
        }

        public static InstrumentalEmissionMeasuring ToInstrumentalEmissionMeasuringFromCreateDTO(this CreateInstrumentalEmissionMeasuringRequestDTO InstrumentalEmissionMeasuringDTO, int StationaryIZAVId)
        {
            return new InstrumentalEmissionMeasuring
            {
                DiameterOfWasteGas = InstrumentalEmissionMeasuringDTO.DiameterOfWasteGas,
                SpeedOfWasteGas = InstrumentalEmissionMeasuringDTO.SpeedOfWasteGas,
                VolumetricFlowRateOfWasteGasNC = InstrumentalEmissionMeasuringDTO.VolumetricFlowRateOfWasteGasNC,
                TrueVolumetricFlowRateOfWasteGas = InstrumentalEmissionMeasuringDTO.TrueVolumetricFlowRateOfWasteGas,
                TemperatureOfWasteGas = InstrumentalEmissionMeasuringDTO.TemperatureOfWasteGas,
                PressureOfWasteGas = InstrumentalEmissionMeasuringDTO.PressureOfWasteGas,
                WaterVaporConcentration = InstrumentalEmissionMeasuringDTO.WaterVaporConcentration,
                StationaryIZAVID = StationaryIZAVId,
            };
        }
        public static InstrumentalEmissionMeasuring ToInstrumentalEmissionMeasuringFromUpdateDTO(this UpdateInstrumentalEmissionMeasuringRequestDTO InstrumentalEmissionMeasuringDTO)
        {
            return new InstrumentalEmissionMeasuring
            {
                DiameterOfWasteGas = InstrumentalEmissionMeasuringDTO.DiameterOfWasteGas,
                SpeedOfWasteGas = InstrumentalEmissionMeasuringDTO.SpeedOfWasteGas,
                VolumetricFlowRateOfWasteGasNC = InstrumentalEmissionMeasuringDTO.VolumetricFlowRateOfWasteGasNC,
                TrueVolumetricFlowRateOfWasteGas = InstrumentalEmissionMeasuringDTO.TrueVolumetricFlowRateOfWasteGas,
                TemperatureOfWasteGas = InstrumentalEmissionMeasuringDTO.TemperatureOfWasteGas,
                PressureOfWasteGas = InstrumentalEmissionMeasuringDTO.PressureOfWasteGas,
                WaterVaporConcentration = InstrumentalEmissionMeasuringDTO.WaterVaporConcentration,
            };
        }

    }
}
