using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IInstrumentalEmissionMeasuring_PollutantRepository
    {
        Task<List<InstrumentalEmissionMeasuring_Pollutant>> GetAllAsync();
        Task<InstrumentalEmissionMeasuring_Pollutant?> GetByIdAsync(int InstrumentalEmissionMeasuringId, int PollutantId);
        Task<InstrumentalEmissionMeasuring_Pollutant> CreateAsync(InstrumentalEmissionMeasuring_Pollutant InstrumentalEmissionMeasuring_PollutantModel);
        Task<InstrumentalEmissionMeasuring_Pollutant> UpdateAsync(int InstrumentalEmissionMeasuringId, int PollutantId, InstrumentalEmissionMeasuring_Pollutant InstrumentalEmissionMeasuring_PollutantModel);
        Task<InstrumentalEmissionMeasuring_Pollutant?> DeleteAsync(int InstrumentalEmissionMeasuringId, int PollutantId);
    }
}
