using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IResultOfGasCleanersInspection_PollutantRepository
    {
        Task<List<ResultOfGasCleanersInspection_Pollutant>> GetAllAsync();
        Task<ResultOfGasCleanersInspection_Pollutant?> GetByIdAsync(int ResultOfGasCleanersInspectionId, int PollutantId);
        Task<ResultOfGasCleanersInspection_Pollutant> CreateAsync(ResultOfGasCleanersInspection_Pollutant ResultOfGasCleanersInspection_PollutantModel);
        Task<ResultOfGasCleanersInspection_Pollutant> UpdateAsync(int ResultOfGasCleanersInspectionId, int PollutantId, ResultOfGasCleanersInspection_Pollutant ResultOfGasCleanersInspection_PollutantModel);
        Task<ResultOfGasCleanersInspection_Pollutant?> DeleteAsync(int ResultOfGasCleanersInspectionId, int PollutantId);
    }
}
