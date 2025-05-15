using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface ISectorRepository
    {
        Task<List<Sector>> GetAllAsync();
        Task<Sector?> GetByIdAsync(int Id);
        Task<Sector> CreateAsync(Sector SectorModel);
        Task<Sector> UpdateAsync(int Id, Sector SectorModel);
        Task<Sector?> DeleteAsync(int Id);
    }
}
