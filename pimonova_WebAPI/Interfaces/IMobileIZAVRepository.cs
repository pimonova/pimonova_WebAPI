using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IMobileIZAVRepository
    {
        Task<List<MobileIZAV>> GetAllAsync();
        Task<MobileIZAV?> GetByIdAsync(int Id);
        Task<MobileIZAV> CreateAsync(MobileIZAV MobileIZAVModel);
        Task<MobileIZAV> UpdateAsync(int Id, MobileIZAV MobileIZAVModel);
        Task<MobileIZAV?> DeleteAsync(int Id);
    }
}
