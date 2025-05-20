using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface ISourceOfPollutants_PollutantRepository
    {
        Task<List<SourceOfPollutants_Pollutant>> GetAllAsync();
        Task<SourceOfPollutants_Pollutant?> GetByIdAsync(int SourceOfPollutantsId, int PollutantId);
        Task<SourceOfPollutants_Pollutant> CreateAsync(SourceOfPollutants_Pollutant SourceOfPollutants_PollutantModel);
        Task<SourceOfPollutants_Pollutant> UpdateAsync(int SourceOfPollutantsId, int PollutantId, SourceOfPollutants_Pollutant SourceOfPollutants_PollutantModel);
        Task<SourceOfPollutants_Pollutant?> DeleteAsync(int SourceOfPollutantsId, int PollutantId);
    }
}
