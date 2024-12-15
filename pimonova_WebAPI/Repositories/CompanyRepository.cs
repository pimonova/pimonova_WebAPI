using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class CompanyRepository : ICompanyRepository
    {
        private readonly ApplicationDbContext _context;
        public CompanyRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> CompanyExists(int Id)
        {
            return _context.Companies.AnyAsync(x => x.Id == Id);
        }

        public async Task<Company> CreateAsync(Company CompanyModel)
        {
            await _context.Companies.AddAsync(CompanyModel);
            await _context.SaveChangesAsync();

            return CompanyModel;
        }

        public async Task<Company?> DeleteAsync(int Id)
        {
            var CompanyModel = await _context.Companies.FirstOrDefaultAsync(x => x.Id == Id);

            if (CompanyModel == null)
            {
                return null;
            }

            _context.Companies.Remove(CompanyModel);
            await _context.SaveChangesAsync();

            return CompanyModel;
        }

        public async Task<List<Company>> GetAllAsync()
        {
            return await _context.Companies.Include(objOONEI => objOONEI.ObjectOfNEI).Include(u => u.Users).ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int Id)
        {
            return await _context.Companies.Include(objOONEI => objOONEI.ObjectOfNEI).Include(u => u.Users).FirstOrDefaultAsync(i => i.Id == Id);
        }

        public async Task<Company?> UpdateAsync(int Id, UpdateCompanyRequestDTO companyRequestDTO)
        {
            var ExistingCompany = await _context.Companies.FirstOrDefaultAsync(x => x.Id == Id);

            if (ExistingCompany == null)
            {
                return null;
            }

            ExistingCompany.FullName = companyRequestDTO.FullName;
            ExistingCompany.ShortName = companyRequestDTO.ShortName;
            ExistingCompany.RegAddress = companyRequestDTO.RegAddress;
            ExistingCompany.CurrAddress = companyRequestDTO.CurrAddress;
            ExistingCompany.PhoneNumber = companyRequestDTO.PhoneNumber;
            ExistingCompany.INN = companyRequestDTO.INN;
            ExistingCompany.KPP = companyRequestDTO.KPP;
            ExistingCompany.OGRN = companyRequestDTO.OGRN;
            ExistingCompany.Director = companyRequestDTO.Director;
            ExistingCompany.LineOfWork = companyRequestDTO.LineOfWork;

            await _context.SaveChangesAsync();

            return ExistingCompany;
        }
    }
}
