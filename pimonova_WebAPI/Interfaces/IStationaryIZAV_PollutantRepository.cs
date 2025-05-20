using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IStationaryIZAV_PollutantRepository
    {
        Task<List<StationaryIZAV_Pollutant>> GetAllAsync();
        Task<StationaryIZAV_Pollutant?> GetByIdAsync(int StationaryIZAVId, int PollutantId);
        Task<StationaryIZAV_Pollutant> CreateAsync(StationaryIZAV_Pollutant StationaryIZAV_PollutantModel);
        Task<StationaryIZAV_Pollutant> UpdateAsync(int StationaryIZAVId, int PollutantId, StationaryIZAV_Pollutant StationaryIZAV_PollutantModel);
        Task<StationaryIZAV_Pollutant?> DeleteAsync(int StationaryIZAVId, int PollutantId);
    }
}
