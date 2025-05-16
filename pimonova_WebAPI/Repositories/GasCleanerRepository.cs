using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class GasCleanerRepository : IGasCleanerRepository
    {
        private readonly ApplicationDbContext _context;
        public GasCleanerRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<GasCleaner> CreateAsync(GasCleaner GasCleanerModel)
        {
            throw new NotImplementedException();
        }

        public async Task<GasCleaner?> DeleteAsync(int Id)
        {
            var GasCleanerModel = await _context.GasCleaners.FirstOrDefaultAsync(x => x.SectorID == Id);

            if (GasCleanerModel == null)
            {
                return null;
            }

            _context.GasCleaners.Remove(GasCleanerModel);
            await _context.SaveChangesAsync();

            return GasCleanerModel;
        }

        public async Task<List<GasCleaner>> GetAllAsync()
        {
            return await _context.GasCleaners.ToListAsync();
        }

        public async Task<GasCleaner?> GetByIdAsync(int Id)
        {
            return await _context.GasCleaners.FindAsync(Id);
        }

        public async Task<GasCleaner> UpdateAsync(int Id, GasCleaner GasCleanerModel)
        {
            throw new NotImplementedException();
        }
    }
}
