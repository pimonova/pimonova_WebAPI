using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IGasCleanerRepository
    {
        Task<List<GasCleaner>> GetAllAsync();
        Task<GasCleaner?> GetByIdAsync(int Id);
        Task<GasCleaner> CreateAsync(GasCleaner GasCleanerModel);
        Task<GasCleaner> UpdateAsync(int Id, GasCleaner GasCleanerModel);
        Task<GasCleaner?> DeleteAsync(int Id);
    }
}
