using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface IAuthRepository
    {
        Task<User?> GetFromLoginAndPassword(string Usrname, string Passwrd);
    }
}
