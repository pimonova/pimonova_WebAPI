using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.DTOs.Company;
using pimonova_WebAPI.Helpers;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;
using System.Linq;

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
            return _context.Companies.AnyAsync(x => x.CompanyID == Id);
        }

        public async Task<Company> CreateAsync(Company CompanyModel)
        {
            await _context.Companies.AddAsync(CompanyModel);
            await _context.SaveChangesAsync();

            return CompanyModel;
        }

        public async Task<Company?> DeleteAsync(int Id)
        {
            var CompanyModel = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyID == Id);

            if (CompanyModel == null)
            {
                return null;
            }

            _context.Companies.Remove(CompanyModel);
            await _context.SaveChangesAsync();

            return CompanyModel;
        }

        public async Task<List<Company>> GetAllAsync(QueryObjectForCompany query)
        {
            var Companies = _context.Companies.Include(objOONEI => objOONEI.ObjectOfNEI).Include(u => u.Users).AsQueryable();

            if (!string.IsNullOrWhiteSpace(query.FullName))
            {
                Companies = Companies.Where(c => c.FullName.Contains(query.FullName));
            }

            if (!string.IsNullOrWhiteSpace(query.ShortName))
            {
                Companies = Companies.Where(c => c.ShortName.Contains(query.ShortName));
            }

            if (!string.IsNullOrWhiteSpace(query.LineOfWork))
            {
                Companies = Companies.Where(c => c.LineOfWork.Contains(query.LineOfWork));
            }

            if (!string.IsNullOrWhiteSpace(query.SortBy))
            {
                if (query.SortBy.Equals("INN", StringComparison.OrdinalIgnoreCase))
                {
                    Companies = query.IsDecsending ? Companies.OrderByDescending(c => c.INN) : Companies.OrderBy(c => c.INN);
                }
                if (query.SortBy.Equals("FullName", StringComparison.OrdinalIgnoreCase))
                {
                    Companies = query.IsDecsending ? Companies.OrderByDescending(c => c.FullName) : Companies.OrderBy(c => c.FullName);
                }
                if (query.SortBy.Equals("Id", StringComparison.OrdinalIgnoreCase))
                {
                    Companies = query.IsDecsending ? Companies.OrderByDescending(c => c.CompanyID) : Companies.OrderBy(c => c.CompanyID);
                }
            }

            return await Companies.ToListAsync();
        }

        public async Task<Company?> GetByIdAsync(int Id)
        {
            return await _context.Companies.Include(objOONEI => objOONEI.ObjectOfNEI).Include(u => u.Users).FirstOrDefaultAsync(i => i.CompanyID == Id);
        }

        public async Task<Company?> UpdateAsync(int Id, UpdateCompanyRequestDTO companyRequestDTO)
        {
            var ExistingCompany = await _context.Companies.FirstOrDefaultAsync(x => x.CompanyID == Id);

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

        public async Task<List<CompanyWithCountedObjectsOfNEIDTO>> GetCountObjectsOfNEIAsync()
        {
            var CompanyWithObjectsofNEICount = from Company in _context.Companies
                                               join ObjectOfNEI in _context.ObjectsOfNEI on Company.CompanyID equals ObjectOfNEI.CompanyID into groupedObjects
                                               select new CompanyWithCountedObjectsOfNEIDTO
                                               {
                                                   Id = Company.CompanyID,
                                                   ShortName = Company.ShortName,
                                                   INN = Company.INN,
                                                   CountedObjectsOfNEI = groupedObjects.Count()
                                               };

            return await CompanyWithObjectsofNEICount.ToListAsync();
        }

        public async Task<CompanyWithCountedUsersDTO?> GetCountUsersAsync(int Id)
        {
            var CompanyWithUsersCount = from Company in _context.Companies
                                        join User in _context.Users on Company.CompanyID equals User.CompanyID into groupedUsers
                                        where Company.CompanyID == Id
                                        select new CompanyWithCountedUsersDTO
                                        {
                                            Id = Company.CompanyID,
                                            ShortName = Company.ShortName,
                                            INN = Company.INN,
                                            CountedUsers = groupedUsers.Count()
                                        };

            return await CompanyWithUsersCount.FirstOrDefaultAsync();
        }
    }
}
