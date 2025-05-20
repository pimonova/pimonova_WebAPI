using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class MobileIZAV_PollutantRepository : IMobileIZAV_PollutantRepository
    {
        private readonly ApplicationDbContext _context;
        public MobileIZAV_PollutantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<MobileIZAV_Pollutant> CreateAsync(MobileIZAV_Pollutant MobileIZAV_PollutantModel)
        {
            await _context.MobileIZAVs_Pollutants.AddAsync(MobileIZAV_PollutantModel);
            await _context.SaveChangesAsync();

            return MobileIZAV_PollutantModel;
        }

        public async Task<MobileIZAV_Pollutant?> DeleteAsync(int MobileIZAVId, int PollutantId)
        {
            var MobileIZAV_PollutantModel = await _context.MobileIZAVs_Pollutants.FirstOrDefaultAsync(x => x.MobileIZAVID == MobileIZAVId && x.PollutantID == PollutantId);

            if (MobileIZAV_PollutantModel == null)
            {
                return null;
            }

            _context.MobileIZAVs_Pollutants.Remove(MobileIZAV_PollutantModel);
            await _context.SaveChangesAsync();

            return MobileIZAV_PollutantModel;
        }

        public async Task<List<MobileIZAV_Pollutant>> GetAllAsync()
        {
            return await _context.MobileIZAVs_Pollutants.ToListAsync();
        }

        public async Task<MobileIZAV_Pollutant?> GetByIdAsync(int MobileIZAVId, int PollutantId)
        {
            return await _context.MobileIZAVs_Pollutants.FirstOrDefaultAsync(x => x.MobileIZAVID == MobileIZAVId && x.PollutantID == PollutantId);
        }

        public async Task<MobileIZAV_Pollutant> UpdateAsync(int MobileIZAVId, int PollutantId, MobileIZAV_Pollutant MobileIZAV_PollutantModel)
        {
            var ExistingMobileIZAV_Pollutant = await _context.MobileIZAVs_Pollutants.FindAsync(MobileIZAVId, PollutantId);

            if (ExistingMobileIZAV_Pollutant == null)
            {
                return null;
            }

            ExistingMobileIZAV_Pollutant.MobileIZAVID = MobileIZAV_PollutantModel.MobileIZAVID;
            ExistingMobileIZAV_Pollutant.PollutantID = MobileIZAV_PollutantModel.PollutantID;
            ExistingMobileIZAV_Pollutant.MeanPollutantEmission = MobileIZAV_PollutantModel.MeanPollutantEmission;
            ExistingMobileIZAV_Pollutant.MaxPollutantEmission = MobileIZAV_PollutantModel.MaxPollutantEmission;
            ExistingMobileIZAV_Pollutant.MeasuringMethod = MobileIZAV_PollutantModel.MeasuringMethod;

            await _context.SaveChangesAsync();

            return ExistingMobileIZAV_Pollutant;
        }
    }
}
