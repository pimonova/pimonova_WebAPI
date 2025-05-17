using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.Helpers;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllAsync(QueryObjectForCompany query);
        Task<Company?> GetByIdAsync(int Id);
        Task<Company> CreateAsync(Company CompanyModel);
        Task<Company?> UpdateAsync(int Id, UpdateCompanyRequestDTO CompanyRequestDTO);
        Task<Company?> DeleteAsync(int Id);
        Task<bool> CompanyExists(int Id);
        Task<List<CompanyWithCountedObjectsOfNEIDTO>> GetCountObjectsOfNEIAsync();
        Task<CompanyWithCountedUsersDTO?> GetCountUsersAsync(int Id);
    }
}
