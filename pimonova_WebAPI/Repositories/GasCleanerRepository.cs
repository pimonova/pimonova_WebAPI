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
            await _context.GasCleaners.AddAsync(GasCleanerModel);
            await _context.SaveChangesAsync();

            return GasCleanerModel;
        }

        public async Task<GasCleaner?> DeleteAsync(int Id)
        {
            var GasCleanerModel = await _context.GasCleaners.FirstOrDefaultAsync(x => x.GasCleanerID == Id);

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
            var ExistingGasCleaner = await _context.GasCleaners.FindAsync(Id);

            if (ExistingGasCleaner == null)
            {
                return null;
            }

            ExistingGasCleaner.SectorID = GasCleanerModel.SectorID;
            ExistingGasCleaner.NumberInCompany = GasCleanerModel.NumberInCompany;
            ExistingGasCleaner.Name = GasCleanerModel.Name;
            ExistingGasCleaner.Type = GasCleanerModel.Type;
            ExistingGasCleaner.Brand = GasCleanerModel.Brand;
            ExistingGasCleaner.StationaryIZAVToOut = GasCleanerModel.StationaryIZAVToOut;

            await _context.SaveChangesAsync();

            return ExistingGasCleaner;
        }
    }
}
