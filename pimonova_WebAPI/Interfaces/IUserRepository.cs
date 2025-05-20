using pimonova_WebAPI.Helpers;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IUserRepository
    {
        Task<List<User>> GetAllAsync(QueryObjectForUser query);
        Task<User?> GetByIdAsync(int Id);
        Task<User> CreateAsync(User UserModel);
        Task<User?> UpdateAsync(int Id, User UserModel);
        Task<User?> DeleteAsync(int Id);
        Task UpdatePasswordAsync(User UserModel);
        Task<User?> UpdateUserRoleAsync(int Id, string NewRole);
    }
}
