using System.ComponentModel.DataAnnotations;

namespace pimonova_WebAPI.Models
{
    public class StationaryIZAV
    {
        public int StationaryIZAVID { get; set; }

        public int? SectorID { get; set; }
        public virtual Sector? Sector { get; set; }

        public string Type { get; set; } = string.Empty;

        public string Name { get; set; } = string.Empty;

        public short AmountOfIZAVWithOneNumber { get; set; }

        public float IZAVHeight { get; set; }

        public float? EstuaryDiameter { get; set; }

        public int NumberInCompany { get; set; }

        public float? EstuaryLength { get; set; }

        public float? EstuaryWidth { get; set; }

        public float? ArealZAVWidth { get; set; }

        public short ModeNumber { get; set; }

        public float? OutputSpeedOfGIM { get; set; }

        public float? VolumeOfGIM { get; set; }

        public short? TemperatureOfGIM { get; set; }

        public float? DensityOfGIM { get; set; }

        public virtual ICollection<GasCleaner> GasCleaners { get; set; } = new List<GasCleaner>();

        public virtual ICollection<InstrumentalEmissionMeasuringOfSIZAV> InstrumentalEmissionMeasuringsOfSIZAV { get; set; } = new List<InstrumentalEmissionMeasuringOfSIZAV>();

        public virtual ICollection<SourceOfPollutants> SourcesOfPollutants { get; set; } = new List<SourceOfPollutants>();

        public virtual ICollection<StationaryIZAV_Pollutant> StationaryIZAVs_Pollutants { get; set; } = new List<StationaryIZAV_Pollutant>();
    }
}
