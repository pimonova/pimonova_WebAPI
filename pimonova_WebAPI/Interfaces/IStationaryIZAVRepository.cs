using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IStationaryIZAVRepository
    {
        Task<List<StationaryIZAV>> GetAllAsync();
        Task<StationaryIZAV?> GetByIdAsync(int Id);
        Task<StationaryIZAV> CreateAsync(StationaryIZAV StationaryIZAVModel);
        Task<StationaryIZAV> UpdateAsync(int Id, StationaryIZAV StationaryIZAVModel);
        Task<StationaryIZAV?> DeleteAsync(int Id);
    }
}
