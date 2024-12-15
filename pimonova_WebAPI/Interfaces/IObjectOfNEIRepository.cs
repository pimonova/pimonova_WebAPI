using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IObjectOfNEIRepository
    {
        Task<List<ObjectOfNEI>> GetAllAsync();
        Task<ObjectOfNEI?> GetByIdAsync(int Id);
        Task<ObjectOfNEI> CreateAsync(ObjectOfNEI ObjectOfNEIModel);
        Task<ObjectOfNEI> UpdateAsync(int Id, ObjectOfNEI ObjectOfNEIModel);
        Task<ObjectOfNEI?> DeleteAsync(int Id);
    }
}
