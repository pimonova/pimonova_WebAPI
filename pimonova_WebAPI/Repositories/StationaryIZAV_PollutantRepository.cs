using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class StationaryIZAV_PollutantRepository : IStationaryIZAV_PollutantRepository
    {
        private readonly ApplicationDbContext _context;
        public StationaryIZAV_PollutantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<StationaryIZAV_Pollutant> CreateAsync(StationaryIZAV_Pollutant StationaryIZAV_PollutantModel)
        { 
            await _context.StationaryIZAVs_Pollutants.AddAsync(StationaryIZAV_PollutantModel);
            await _context.SaveChangesAsync();

            return StationaryIZAV_PollutantModel;
        }

        public async Task<StationaryIZAV_Pollutant?> DeleteAsync(int StationaryIZAVId, int PollutantId)
        {
            var StationaryIZAV_PollutantModel = await _context.StationaryIZAVs_Pollutants.FirstOrDefaultAsync(x => x.StationaryIZAVID == StationaryIZAVId && x.PollutantID == PollutantId);

            if (StationaryIZAV_PollutantModel == null)
            {
                return null;
            }

            _context.StationaryIZAVs_Pollutants.Remove(StationaryIZAV_PollutantModel);
            await _context.SaveChangesAsync();

            return StationaryIZAV_PollutantModel;
        }

        public async Task<List<StationaryIZAV_Pollutant>> GetAllAsync()
        {
            return await _context.StationaryIZAVs_Pollutants.ToListAsync();
        }

        public async Task<StationaryIZAV_Pollutant?> GetByIdAsync(int StationaryIZAVId, int PollutantId)
        {
            return await _context.StationaryIZAVs_Pollutants.FirstOrDefaultAsync(x => x.StationaryIZAVID == StationaryIZAVId && x.PollutantID == PollutantId);
        }

        public async Task<StationaryIZAV_Pollutant> UpdateAsync(int StationaryIZAVId, int PollutantId, StationaryIZAV_Pollutant StationaryIZAV_PollutantModel)
        {
            var ExistingStationaryIZAV_Pollutant = await _context.StationaryIZAVs_Pollutants.FindAsync(StationaryIZAVId, PollutantId);

            if (ExistingStationaryIZAV_Pollutant == null)
            {
                return null;
            }

            ExistingStationaryIZAV_Pollutant.StationaryIZAVID = StationaryIZAV_PollutantModel.StationaryIZAVID;
            ExistingStationaryIZAV_Pollutant.PollutantID = StationaryIZAV_PollutantModel.PollutantID;
            ExistingStationaryIZAV_Pollutant.PollutantConcentration = StationaryIZAV_PollutantModel.PollutantConcentration;
            ExistingStationaryIZAV_Pollutant.PollutantEmissionPower = StationaryIZAV_PollutantModel.PollutantEmissionPower;
            ExistingStationaryIZAV_Pollutant.GrossPollutantEmissionTonsPerYear = StationaryIZAV_PollutantModel.GrossPollutantEmissionTonsPerYear;
            ExistingStationaryIZAV_Pollutant.TotalPollutantEmissionTonsPerPeriod = StationaryIZAV_PollutantModel.TotalPollutantEmissionTonsPerPeriod;

            await _context.SaveChangesAsync();

            return ExistingStationaryIZAV_Pollutant;
        }
    }
}
