using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuring;
using pimonova_WebAPI.DTOs.ModeOfIZAVWithNonStationaryEmissions;
using pimonova_WebAPI.Helpers;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IModeOfIZAVWithNonStationaryEmissionsRepository
    {
        Task<List<ModeOfIZAVWithNonStationaryEmissions>> GetAllAsync();
        Task<ModeOfIZAVWithNonStationaryEmissions?> GetByIdAsync(int Id);
        Task<ModeOfIZAVWithNonStationaryEmissions> CreateAsync(ModeOfIZAVWithNonStationaryEmissions ModeOfIZAVWithNonStationaryEmissionsModel);
        Task<ModeOfIZAVWithNonStationaryEmissions?> UpdateAsync(int Id, CreateOrUpdateModeOfIZAVWithNonStationaryEmissionsRequestDTO ModeOfIZAVWithNonStationaryEmissionsRequestDTO);
        Task<ModeOfIZAVWithNonStationaryEmissions?> DeleteAsync(int Id);
        Task<bool> ModeOfIZAVWithNonStationaryEmissionsExists(int Id);
    }
}
