using pimonova_WebAPI.Helpers;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IWorkshopRepository
    {
        Task<List<Workshop>> GetAllAsync();
        Task<Workshop?> GetByIdAsync(int Id);
        Task<Workshop> CreateAsync( Workshop WorkshopModel);
        Task<Workshop> UpdateAsync(int Id, Workshop WorkshopModel);
        Task<Workshop?> DeleteAsync(int Id);
        Task<bool> WorkshopExists(int Id);
    }
}
