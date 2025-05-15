using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface ISourceOfPollutantsRepository
    {
        Task<List<SourceOfPollutants>> GetAllAsync();
        Task<SourceOfPollutants?> GetByIdAsync(int Id);
        Task<SourceOfPollutants> CreateAsync(SourceOfPollutants SourceOfPollutantsModel);
        Task<SourceOfPollutants> UpdateAsync(int Id, SourceOfPollutants SourceOfPollutantsModel);
        Task<SourceOfPollutants?> DeleteAsync(int Id);
    }
}
