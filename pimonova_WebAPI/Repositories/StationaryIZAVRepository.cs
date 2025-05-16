using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class StationaryIZAVRepository : IStationaryIZAVRepository
    {
        private readonly ApplicationDbContext _context;
        public StationaryIZAVRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StationaryIZAV> CreateAsync(StationaryIZAV StationaryIZAVModel)
        {
            await _context.StationaryIZAVs.AddAsync(StationaryIZAVModel);
            await _context.SaveChangesAsync();

            return StationaryIZAVModel;
        }

        public async Task<StationaryIZAV?> DeleteAsync(int Id)
        {
            var StationaryIZAVModel = await _context.StationaryIZAVs.FirstOrDefaultAsync(x => x.SectorID == Id);

            if (StationaryIZAVModel == null)
            {
                return null;
            }

            _context.StationaryIZAVs.Remove(StationaryIZAVModel);
            await _context.SaveChangesAsync();

            return StationaryIZAVModel;
        }

        public async Task<List<StationaryIZAV>> GetAllAsync()
        {
            return await _context.StationaryIZAVs.ToListAsync();
        }

        public async Task<StationaryIZAV?> GetByIdAsync(int Id)
        {
            return await _context.StationaryIZAVs.FindAsync(Id);
        }

        public async Task<StationaryIZAV> UpdateAsync(int Id, StationaryIZAV StationaryIZAVModel)
        {
            throw new NotImplementedException();
        }
    }
}
