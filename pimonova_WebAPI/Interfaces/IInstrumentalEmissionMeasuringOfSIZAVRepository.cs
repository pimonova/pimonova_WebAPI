using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IInstrumentalEmissionMeasuringOfSIZAVRepository
    {
        Task<List<InstrumentalEmissionMeasuringOfSIZAV>> GetAllAsync();
        Task<InstrumentalEmissionMeasuringOfSIZAV?> GetByIdAsync(int Id);
        Task<InstrumentalEmissionMeasuringOfSIZAV> CreateAsync(InstrumentalEmissionMeasuringOfSIZAV InstrumentalEmissionMeasuringOfSIZAVModel);
        Task<InstrumentalEmissionMeasuringOfSIZAV> UpdateAsync(int Id, InstrumentalEmissionMeasuringOfSIZAV InstrumentalEmissionMeasuringOfSIZAVModel);
        Task<InstrumentalEmissionMeasuringOfSIZAV?> DeleteAsync(int Id);
    }
}
