using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class SectorRepository : ISectorRepository
    {
        private readonly ApplicationDbContext _context;
        public SectorRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Sector> CreateAsync(Sector SectorModel)
        {
            await _context.Sectors.AddAsync(SectorModel);
            await _context.SaveChangesAsync();

            return SectorModel;
        }

        public async Task<Sector?> DeleteAsync(int Id)
        {
            var SectorModel = await _context.Sectors.FirstOrDefaultAsync(x => x.SectorID == Id);

            if (SectorModel == null)
            {
                return null;
            }

            _context.Sectors.Remove(SectorModel);
            await _context.SaveChangesAsync();

            return SectorModel;
        }

        public async Task<List<Sector>> GetAllAsync()
        {
            return await _context.Sectors.ToListAsync();
        }

        public async Task<Sector?> GetByIdAsync(int Id)
        {
            return await _context.Sectors.FindAsync(Id);
        }

        public async Task<Sector> UpdateAsync(int Id, Sector SectorModel)
        {
            var ExistingSector = await _context.Sectors.FindAsync(Id);

            if (ExistingSector == null)
            {
                return null;
            }

            ExistingSector.NumberInCompany = SectorModel.NumberInCompany;
            ExistingSector.Name = SectorModel.Name;

            await _context.SaveChangesAsync();

            return ExistingSector;
        }
    }
}
