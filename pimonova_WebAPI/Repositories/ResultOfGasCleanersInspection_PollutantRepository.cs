using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class ResultOfGasCleanersInspection_PollutantRepository : IResultOfGasCleanersInspection_PollutantRepository
    {
        private readonly ApplicationDbContext _context;
        public ResultOfGasCleanersInspection_PollutantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultOfGasCleanersInspection_Pollutant> CreateAsync(ResultOfGasCleanersInspection_Pollutant ResultOfGasCleanersInspection_PollutantModel)
        {
            await _context.ResultsOfGasCleanersInspection_Pollutants.AddAsync(ResultOfGasCleanersInspection_PollutantModel);
            await _context.SaveChangesAsync();

            return ResultOfGasCleanersInspection_PollutantModel;
        }

        public async Task<ResultOfGasCleanersInspection_Pollutant?> DeleteAsync(int ResultOfGasCleanersInspectionId, int PollutantId)
        {
            var ResultOfGasCleanersInspection_PollutantModel = await _context.ResultsOfGasCleanersInspection_Pollutants.FirstOrDefaultAsync(x => x.ResultOfGasCleanersInspectionID == ResultOfGasCleanersInspectionId && x.PollutantID == PollutantId);

            if (ResultOfGasCleanersInspection_PollutantModel == null)
            {
                return null;
            }

            _context.ResultsOfGasCleanersInspection_Pollutants.Remove(ResultOfGasCleanersInspection_PollutantModel);
            await _context.SaveChangesAsync();

            return ResultOfGasCleanersInspection_PollutantModel;
        }

        public async Task<List<ResultOfGasCleanersInspection_Pollutant>> GetAllAsync()
        {
            return await _context.ResultsOfGasCleanersInspection_Pollutants.ToListAsync();
        }

        public async Task<ResultOfGasCleanersInspection_Pollutant?> GetByIdAsync(int ResultOfGasCleanersInspectionId, int PollutantId)
        {
            return await _context.ResultsOfGasCleanersInspection_Pollutants.FirstOrDefaultAsync(x => x.ResultOfGasCleanersInspectionID == ResultOfGasCleanersInspectionId && x.PollutantID == PollutantId);
        }

        public async Task<ResultOfGasCleanersInspection_Pollutant> UpdateAsync(int ResultOfGasCleanersInspectionId, int PollutantId, ResultOfGasCleanersInspection_Pollutant ResultOfGasCleanersInspection_PollutantModel)
        {
            var ExistingResultOfGasCleanersInspection_Pollutant = await _context.ResultsOfGasCleanersInspection_Pollutants.FindAsync(ResultOfGasCleanersInspectionId, PollutantId);

            if (ExistingResultOfGasCleanersInspection_Pollutant == null)
            {
                return null;
            }

            ExistingResultOfGasCleanersInspection_Pollutant.ResultOfGasCleanersInspectionID = ResultOfGasCleanersInspection_PollutantModel.ResultOfGasCleanersInspectionID;
            ExistingResultOfGasCleanersInspection_Pollutant.PollutantID = ResultOfGasCleanersInspection_PollutantModel.PollutantID;

            await _context.SaveChangesAsync();

            return ExistingResultOfGasCleanersInspection_Pollutant;
        }
    }
}
