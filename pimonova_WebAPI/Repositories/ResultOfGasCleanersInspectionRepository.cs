using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;
using pimonova_WebAPI.DTOs.ResultOfGasCleanersInspection;
using pimonova_WebAPI.Mappers;

namespace pimonova_WebAPI.Repositories
{
    public class ResultOfGasCleanersInspectionRepository : IResultOfGasCleanersInspectionRepository
    {
        private readonly ApplicationDbContext _context;
        public ResultOfGasCleanersInspectionRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ResultOfGasCleanersInspection> CreateAsync(ResultOfGasCleanersInspection ResultOfGasCleanersInspectionModel)
        {
            await _context.ResultsOfGasCleanersInspection.AddAsync(ResultOfGasCleanersInspectionModel);
            await _context.SaveChangesAsync();

            return ResultOfGasCleanersInspectionModel;
        }

        public async Task<ResultOfGasCleanersInspection?> DeleteAsync(int Id)
        {
            var ResultOfGasCleanersInspectionModel = await _context.ResultsOfGasCleanersInspection.FirstOrDefaultAsync(x => x.ResultID == Id);

            if (ResultOfGasCleanersInspectionModel == null)
            {
                return null;
            }

            _context.ResultsOfGasCleanersInspection.Remove(ResultOfGasCleanersInspectionModel);
            await _context.SaveChangesAsync();

            return ResultOfGasCleanersInspectionModel;
        }

        public async Task<List<ResultOfGasCleanersInspection>> GetAllAsync()
        {
            return await _context.ResultsOfGasCleanersInspection.ToListAsync();
        }

        public async Task<ResultOfGasCleanersInspection?> GetByIdAsync(int Id)
        {
            return await _context.ResultsOfGasCleanersInspection.FindAsync(Id);
        }

        public Task<bool> ResultOfGasCleanersInspectionExists(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<ResultOfGasCleanersInspection?> UpdateAsync(int Id, ResultOfGasCleanersInspection ResultOfGasCleanersInspectionModel)
        {
            var ExistingResultOfGasCleanersInspection = await _context.ResultsOfGasCleanersInspection.FindAsync(Id);

            if (ExistingResultOfGasCleanersInspection == null)
            {
                return null;
            }

            ExistingResultOfGasCleanersInspection.ProjectCleaningDegree = ResultOfGasCleanersInspectionModel.ProjectCleaningDegree;
            ExistingResultOfGasCleanersInspection.TrueCleaningDegree = ResultOfGasCleanersInspectionModel.TrueCleaningDegree;
            ExistingResultOfGasCleanersInspection.ProjectProvisionCoeff = ResultOfGasCleanersInspectionModel.ProjectProvisionCoeff;
            ExistingResultOfGasCleanersInspection.TrueProvisionCoeff = ResultOfGasCleanersInspectionModel.TrueProvisionCoeff;

            await _context.SaveChangesAsync();

            return ExistingResultOfGasCleanersInspection;
        }

    }
}
