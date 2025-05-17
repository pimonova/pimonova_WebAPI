using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;
using pimonova_WebAPI.DTOs.Pollutant;

namespace pimonova_WebAPI.Repositories
{
    public class PollutantRepository : IPollutantRepository
    {
        private readonly ApplicationDbContext _context;
        public PollutantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Pollutant> CreateAsync(Pollutant PollutantModel)
        {
            await _context.Pollutants.AddAsync(PollutantModel);
            await _context.SaveChangesAsync();

            return PollutantModel;
        }

        public async Task<Pollutant?> DeleteAsync(int Id)
        {
            var PollutantModel = await _context.Pollutants.FirstOrDefaultAsync(x => x.PollutantID == Id);

            if (PollutantModel == null)
            {
                return null;
            }

            _context.Pollutants.Remove(PollutantModel);
            await _context.SaveChangesAsync();

            return PollutantModel;
        }

        public async Task<List<Pollutant>> GetAllAsync()
        {
            return await _context.Pollutants.ToListAsync();
        }

        public async Task<Pollutant?> GetByIdAsync(int Id)
        {
            return await _context.Pollutants.FindAsync(Id);
        }

        public Task<bool> PollutantExists(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<Pollutant?> UpdateAsync(int Id, CreateOrUpdatePollutantRequestDTO PollutantRequestDTO)
        {
            var Pollutant = await _context.Pollutants.FirstOrDefaultAsync(x => x.PollutantID == Id);

            if (Pollutant == null)
            {
                return null;
            }

            Pollutant.Code = PollutantRequestDTO.Code;
            Pollutant.Name = PollutantRequestDTO.Name;

            await _context.SaveChangesAsync();

            return Pollutant;
        }
    }
}
