using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class SourceOfPollutants_PollutantRepository : ISourceOfPollutants_PollutantRepository
    {
        private readonly ApplicationDbContext _context;
        public SourceOfPollutants_PollutantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SourceOfPollutants_Pollutant> CreateAsync(SourceOfPollutants_Pollutant SourceOfPollutants_PollutantModel)
        {
            await _context.SourcesOfPollutants_Pollutants.AddAsync(SourceOfPollutants_PollutantModel);
            await _context.SaveChangesAsync();

            return SourceOfPollutants_PollutantModel;
        }

        public async Task<SourceOfPollutants_Pollutant?> DeleteAsync(int SourceOfPollutantsId, int PollutantId)
        {
            var SourceOfPollutants_PollutantModel = await _context.SourcesOfPollutants_Pollutants.FirstOrDefaultAsync(x => x.SourceOfPollutantsID == SourceOfPollutantsId && x.PollutantID == PollutantId);

            if (SourceOfPollutants_PollutantModel == null)
            {
                return null;
            }

            _context.SourcesOfPollutants_Pollutants.Remove(SourceOfPollutants_PollutantModel);
            await _context.SaveChangesAsync();

            return SourceOfPollutants_PollutantModel;
        }

        public async Task<List<SourceOfPollutants_Pollutant>> GetAllAsync()
        {
            return await _context.SourcesOfPollutants_Pollutants.ToListAsync();
        }

        public async Task<SourceOfPollutants_Pollutant?> GetByIdAsync(int SourceOfPollutantsId, int PollutantId)
        {
            return await _context.SourcesOfPollutants_Pollutants.FirstOrDefaultAsync(x => x.SourceOfPollutantsID == SourceOfPollutantsId && x.PollutantID == PollutantId);
        }

        public async Task<SourceOfPollutants_Pollutant> UpdateAsync(int SourceOfPollutantsId, int PollutantId, SourceOfPollutants_Pollutant SourceOfPollutants_PollutantModel)
        {
            var ExistingSourceOfPollutants_Pollutant = await _context.SourcesOfPollutants_Pollutants.FindAsync(SourceOfPollutantsId, PollutantId);

            if (ExistingSourceOfPollutants_Pollutant == null)
            {
                return null;
            }

            ExistingSourceOfPollutants_Pollutant.SourceOfPollutantsID = SourceOfPollutants_PollutantModel.SourceOfPollutantsID;
            ExistingSourceOfPollutants_Pollutant.PollutantID = SourceOfPollutants_PollutantModel.PollutantID;
            ExistingSourceOfPollutants_Pollutant.PollutantAmountGramsPerSecond = SourceOfPollutants_PollutantModel.PollutantAmountGramsPerSecond;
            ExistingSourceOfPollutants_Pollutant.PollutantAmountTonsPerYear = SourceOfPollutants_PollutantModel.PollutantAmountTonsPerYear;
            ExistingSourceOfPollutants_Pollutant.TotalPollutantAmountTonsPerYear = SourceOfPollutants_PollutantModel.TotalPollutantAmountTonsPerYear;

            await _context.SaveChangesAsync();

            return ExistingSourceOfPollutants_Pollutant;
        }
    }
}
