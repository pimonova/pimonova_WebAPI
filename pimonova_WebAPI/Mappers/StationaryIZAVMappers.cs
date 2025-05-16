using pimonova_WebAPI.DTOs.MobileIZAV;
using pimonova_WebAPI.DTOs.Sector;
using pimonova_WebAPI.DTOs.StationaryIZAV;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Mappers
{
    public static class StationaryIZAVMappers
    {
        public static StationaryIZAVDTO ToStationaryIZAVDTO(this StationaryIZAV StationaryIZAVModel)
        {
            return new StationaryIZAVDTO
            {
                StationaryIZAVID = StationaryIZAVModel.StationaryIZAVID,
                SectorID = StationaryIZAVModel.SectorID,
                Type = StationaryIZAVModel.Type,
                Name = StationaryIZAVModel.Name,
                AmountOfIZAVWithOneNumber = StationaryIZAVModel.AmountOfIZAVWithOneNumber,
                IZAVHeight = StationaryIZAVModel.IZAVHeight,
                EstuaryDiameter = StationaryIZAVModel.EstuaryDiameter,
                NumberInCompany = StationaryIZAVModel.NumberInCompany,
                EstuaryLength = StationaryIZAVModel.EstuaryLength,
                EstuaryWidth = StationaryIZAVModel.EstuaryWidth,
                ArealZAVWidth = StationaryIZAVModel.ArealZAVWidth,
                ModeNumber = StationaryIZAVModel.ModeNumber,
                OutputSpeedOfGAM = StationaryIZAVModel.OutputSpeedOfGAM,
                VolumeOfGAM = StationaryIZAVModel.VolumeOfGAM,
                TemperatureOfGAM = StationaryIZAVModel.TemperatureOfGAM,
                DensityOfGAM = StationaryIZAVModel.DensityOfGAM,
            };
        }

        public static StationaryIZAV ToStationaryIZAVFromCreateDTO(this CreateStationaryIZAVRequestDTO StationaryIZAVDTO, int SectorId)
        {
            return new StationaryIZAV
            {
                Type = StationaryIZAVDTO.Type,
                Name = StationaryIZAVDTO.Name,
                AmountOfIZAVWithOneNumber = StationaryIZAVDTO.AmountOfIZAVWithOneNumber,
                IZAVHeight = StationaryIZAVDTO.IZAVHeight,
                EstuaryDiameter = StationaryIZAVDTO.EstuaryDiameter,
                NumberInCompany = StationaryIZAVDTO.NumberInCompany,
                EstuaryLength = StationaryIZAVDTO.EstuaryLength,
                EstuaryWidth = StationaryIZAVDTO.EstuaryWidth,
                ArealZAVWidth = StationaryIZAVDTO.ArealZAVWidth,
                ModeNumber = StationaryIZAVDTO.ModeNumber,
                OutputSpeedOfGAM = StationaryIZAVDTO.OutputSpeedOfGAM,
                VolumeOfGAM = StationaryIZAVDTO.VolumeOfGAM,
                TemperatureOfGAM = StationaryIZAVDTO.TemperatureOfGAM,
                DensityOfGAM = StationaryIZAVDTO.DensityOfGAM,
                SectorID = SectorId,
            };
        }

        public static StationaryIZAV ToStationaryIZAVFromUpdateDTO(this UpdateStationaryIZAVRequestDTO StationaryIZAVDTO)
        {
            return new StationaryIZAV
            {
                Type = StationaryIZAVDTO.Type,
                Name = StationaryIZAVDTO.Name,
                AmountOfIZAVWithOneNumber = StationaryIZAVDTO.AmountOfIZAVWithOneNumber,
                IZAVHeight = StationaryIZAVDTO.IZAVHeight,
                EstuaryDiameter = StationaryIZAVDTO.EstuaryDiameter,
                NumberInCompany = StationaryIZAVDTO.NumberInCompany,
                EstuaryLength = StationaryIZAVDTO.EstuaryLength,
                EstuaryWidth = StationaryIZAVDTO.EstuaryWidth,
                ArealZAVWidth = StationaryIZAVDTO.ArealZAVWidth,
                ModeNumber = StationaryIZAVDTO.ModeNumber,
                OutputSpeedOfGAM = StationaryIZAVDTO.OutputSpeedOfGAM,
                VolumeOfGAM = StationaryIZAVDTO.VolumeOfGAM,
                TemperatureOfGAM = StationaryIZAVDTO.TemperatureOfGAM,
                DensityOfGAM = StationaryIZAVDTO.DensityOfGAM,
            };
        }
    }
}
