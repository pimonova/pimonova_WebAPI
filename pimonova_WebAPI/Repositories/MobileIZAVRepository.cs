using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

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
            var MobileIZAVModel = await _context.MobileIZAVs.FirstOrDefaultAsync(x => x.SectorID == Id);

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
            throw new NotImplementedException();
        }
    }
}
