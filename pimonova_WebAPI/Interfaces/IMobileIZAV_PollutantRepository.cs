using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IMobileIZAV_PollutantRepository
    {
        Task<List<MobileIZAV_Pollutant>> GetAllAsync();
        Task<MobileIZAV_Pollutant?> GetByIdAsync(int MobileIZAVId, int PollutantId);
        Task<MobileIZAV_Pollutant> CreateAsync(MobileIZAV_Pollutant MobileIZAV_PollutantModel);
        Task<MobileIZAV_Pollutant> UpdateAsync(int MobileIZAVId, int PollutantId, MobileIZAV_Pollutant MobileIZAV_PollutantModel);
        Task<MobileIZAV_Pollutant?> DeleteAsync(int MobileIZAVId, int PollutantId);
    }
}
