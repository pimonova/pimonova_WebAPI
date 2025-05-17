using pimonova_WebAPI.DTOs.Pollutant;
using pimonova_WebAPI.Models;
using System.Threading.Tasks;

namespace pimonova_WebAPI.Interfaces
{
    public interface IPollutantRepository
    {
        Task<List<Pollutant>> GetAllAsync();
        Task<Pollutant?> GetByIdAsync(int Id);
        Task<Pollutant> CreateAsync(Pollutant PollutantModel);
        Task<Pollutant?> UpdateAsync(int Id, CreateOrUpdatePollutantRequestDTO PollutantRequestDTO);
        Task<Pollutant?> DeleteAsync(int Id);
        Task<bool> PollutantExists(int Id);
    }
}
