﻿using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Interfaces
{
    public interface ICompanyRepository
    {
        Task<List<Company>> GetAllAsync();
        Task<Company?> GetByIdAsync(int Id);
        Task<Company> CreateAsync(Company CompanyModel);
        Task<Company?> UpdateAsync(int Id, UpdateCompanyRequestDTO companyRequestDTO);
        Task<Company?> DeleteAsync(int Id);
    }
}
