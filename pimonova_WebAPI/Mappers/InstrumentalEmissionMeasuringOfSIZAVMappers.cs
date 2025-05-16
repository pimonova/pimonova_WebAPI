using pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuringOfSIZAV;
using pimonova_WebAPI.DTOs.StationaryIZAV;
using pimonova_WebAPI.Models;
using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Mappers
{
    public static class InstrumentalEmissionMeasuringOfSIZAVMappers
    {
        public static InstrumentalEmissionMeasuringOfSIZAVDTO ToInstrumentalEmissionMeasuringOfSIZAVDTO(this InstrumentalEmissionMeasuringOfSIZAV InstrumentalEmissionMeasuringOfSIZAVModel)
        {
            return new InstrumentalEmissionMeasuringOfSIZAVDTO
            {
                ResultID = InstrumentalEmissionMeasuringOfSIZAVModel.ResultID,
                StationaryIZAVID = InstrumentalEmissionMeasuringOfSIZAVModel.StationaryIZAVID,
                DiameterOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVModel.DiameterOfWasteGas,
                SpeedOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVModel.SpeedOfWasteGas,
                VolumetricFlowRateOfWasteGasNC = InstrumentalEmissionMeasuringOfSIZAVModel.VolumetricFlowRateOfWasteGasNC,
                TrueVolumetricFlowRateOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVModel.TrueVolumetricFlowRateOfWasteGas,
                TemperatureOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVModel.TemperatureOfWasteGas,
                PressureOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVModel.PressureOfWasteGas,
                WaterVaporConcentration = InstrumentalEmissionMeasuringOfSIZAVModel.WaterVaporConcentration,
            };
        }

        public static InstrumentalEmissionMeasuringOfSIZAV ToInstrumentalEmissionMeasuringOfSIZAVFromCreateDTO(this CreateInstrumentalEmissionMeasuringOfSIZAVRequestDTO InstrumentalEmissionMeasuringOfSIZAVDTO, int StationaryIZAVId)
        {
            return new InstrumentalEmissionMeasuringOfSIZAV
            {
                DiameterOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVDTO.DiameterOfWasteGas,
                SpeedOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVDTO.SpeedOfWasteGas,
                VolumetricFlowRateOfWasteGasNC = InstrumentalEmissionMeasuringOfSIZAVDTO.VolumetricFlowRateOfWasteGasNC,
                TrueVolumetricFlowRateOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVDTO.TrueVolumetricFlowRateOfWasteGas,
                TemperatureOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVDTO.TemperatureOfWasteGas,
                PressureOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVDTO.PressureOfWasteGas,
                WaterVaporConcentration = InstrumentalEmissionMeasuringOfSIZAVDTO.WaterVaporConcentration,
                StationaryIZAVID = StationaryIZAVId,
            };
        }
        public static InstrumentalEmissionMeasuringOfSIZAV ToInstrumentalEmissionMeasuringOfSIZAVFromUpdateDTO(this UpdateInstrumentalEmissionMeasuringOfSIZAVRequestDTO InstrumentalEmissionMeasuringOfSIZAVDTO)
        {
            return new InstrumentalEmissionMeasuringOfSIZAV
            {
                DiameterOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVDTO.DiameterOfWasteGas,
                SpeedOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVDTO.SpeedOfWasteGas,
                VolumetricFlowRateOfWasteGasNC = InstrumentalEmissionMeasuringOfSIZAVDTO.VolumetricFlowRateOfWasteGasNC,
                TrueVolumetricFlowRateOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVDTO.TrueVolumetricFlowRateOfWasteGas,
                TemperatureOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVDTO.TemperatureOfWasteGas,
                PressureOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVDTO.PressureOfWasteGas,
                WaterVaporConcentration = InstrumentalEmissionMeasuringOfSIZAVDTO.WaterVaporConcentration,
            };
        }

    }
}
