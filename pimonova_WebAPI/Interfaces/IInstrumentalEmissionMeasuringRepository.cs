using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IInstrumentalEmissionMeasuringRepository
    {
        Task<List<InstrumentalEmissionMeasuring>> GetAllAsync();
        Task<InstrumentalEmissionMeasuring?> GetByIdAsync(int Id);
        Task<InstrumentalEmissionMeasuring> CreateAsync(InstrumentalEmissionMeasuring InstrumentalEmissionMeasuringModel);
        Task<InstrumentalEmissionMeasuring> UpdateAsync(int Id, InstrumentalEmissionMeasuring InstrumentalEmissionMeasuringModel);
        Task<InstrumentalEmissionMeasuring?> DeleteAsync(int Id);
        Task<bool> InstrumentalEmissionMeasuringExists(int Id);
    }
}
