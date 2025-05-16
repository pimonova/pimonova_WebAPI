using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.DTOs.MobileIZAV;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;
using System.Xml.Linq;

namespace pimonova_WebAPI.Repositories
{
    public class MobileIZAVRepository : IMobileIZAVRepository
    {
        private readonly ApplicationDbContext _context;
        public MobileIZAVRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MobileIZAV> CreateAsync(MobileIZAV MobileIZAVModel)
        {
            await _context.MobileIZAVs.AddAsync(MobileIZAVModel);
            await _context.SaveChangesAsync();

            return MobileIZAVModel;
        }

        public async Task<MobileIZAV?> DeleteAsync(int Id)
        {
            var MobileIZAVModel = await _context.MobileIZAVs.FirstOrDefaultAsync(x => x.MobileIZAVID == Id);

            if (MobileIZAVModel == null)
            {
                return null;
            }

            _context.MobileIZAVs.Remove(MobileIZAVModel);
            await _context.SaveChangesAsync();

            return MobileIZAVModel;
        }

        public async Task<List<MobileIZAV>> GetAllAsync()
        {
            return await _context.MobileIZAVs.ToListAsync();
        }

        public async Task<MobileIZAV?> GetByIdAsync(int Id)
        {
            return await _context.MobileIZAVs.FindAsync(Id);
        }

        public async Task<MobileIZAV> UpdateAsync(int Id, MobileIZAV MobileIZAVModel)
        {
            var ExistingMobileIZAV = await _context.MobileIZAVs.FindAsync(Id);

            if (ExistingMobileIZAV == null)
            {
                return null;
            }

            ExistingMobileIZAV.Name = MobileIZAVModel.Name;
            ExistingMobileIZAV.NumberInCompany = MobileIZAVModel.NumberInCompany;
            ExistingMobileIZAV.AmountOfIZAVWithOneNumber = MobileIZAVModel.AmountOfIZAVWithOneNumber;
            ExistingMobileIZAV.Speed = MobileIZAVModel.Speed;
            ExistingMobileIZAV.Fuel = MobileIZAVModel.Fuel;
            ExistingMobileIZAV.WorkingHoursPerSeason = MobileIZAVModel.WorkingHoursPerSeason;
            ExistingMobileIZAV.WorkingHoursPerYear = MobileIZAVModel.WorkingHoursPerYear;

            await _context.SaveChangesAsync();

            return ExistingMobileIZAV;
        }
    }
}
