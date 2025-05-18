using pimonova_WebAPI.DTOs.Pollutant;
using pimonova_WebAPI.Models;
using pimonova_WebAPI.DTOs.ResultOfGasCleanersInspection;

namespace pimonova_WebAPI.Interfaces
{
    public interface IResultOfGasCleanersInspectionRepository
    {
        Task<List<ResultOfGasCleanersInspection>> GetAllAsync();
        Task<ResultOfGasCleanersInspection?> GetByIdAsync(int Id);
        Task<ResultOfGasCleanersInspection> CreateAsync(ResultOfGasCleanersInspection ResultOfGasCleanersInspectionModel);
        Task<ResultOfGasCleanersInspection?> UpdateAsync(int Id, ResultOfGasCleanersInspection ResultOfGasCleanersInspectionModel);
        Task<ResultOfGasCleanersInspection?> DeleteAsync(int Id);
        Task<bool> ResultOfGasCleanersInspectionExists(int Id);
    }
}
