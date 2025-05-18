using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.DTOs.SourceOfPollutants;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class SourceOfPollutantsRepository : ISourceOfPollutantsRepository
    {
        private readonly ApplicationDbContext _context;
        public SourceOfPollutantsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<SourceOfPollutants> CreateAsync(SourceOfPollutants SourceOfPollutantsModel)
        {
            await _context.SourcesOfPollutants.AddAsync(SourceOfPollutantsModel);
            await _context.SaveChangesAsync();

            return SourceOfPollutantsModel;
        }

        public async Task<SourceOfPollutants?> DeleteAsync(int Id)
        {
            var SourceOfPollutantsModel = await _context.SourcesOfPollutants.FirstOrDefaultAsync(x => x.SourceID == Id);

            if (SourceOfPollutantsModel == null)
            {
                return null;
            }

            _context.SourcesOfPollutants.Remove(SourceOfPollutantsModel);
            await _context.SaveChangesAsync();

            return SourceOfPollutantsModel;
        }

        public async Task<List<SourceOfPollutants>> GetAllAsync()
        {
            return await _context.SourcesOfPollutants.ToListAsync();
        }

        public async Task<SourceOfPollutants?> GetByIdAsync(int Id)
        {
            return await _context.SourcesOfPollutants.FindAsync(Id);
        }

        public Task<bool> SourceOfPollutantsExists(int Id)
        {
            return _context.SourcesOfPollutants.AnyAsync(x => x.SourceID == Id);
        }

        public async Task<SourceOfPollutants> UpdateAsync(int Id, SourceOfPollutants SourceOfPollutantsModel)
        {
            var ExistingSourceOfPollutants = await _context.SourcesOfPollutants.FindAsync(Id);

            if (ExistingSourceOfPollutants == null)
            {
                return null;
            }

            ExistingSourceOfPollutants.SectorID = SourceOfPollutantsModel.SectorID;
            ExistingSourceOfPollutants.NumberInCompany = SourceOfPollutantsModel.NumberInCompany;
            ExistingSourceOfPollutants.Name = SourceOfPollutantsModel.Name;
            ExistingSourceOfPollutants.ModeNumber = SourceOfPollutantsModel.ModeNumber;
            ExistingSourceOfPollutants.WorkingHoursPerDay = SourceOfPollutantsModel.WorkingHoursPerDay;
            ExistingSourceOfPollutants.WorkingHoursPerYear = SourceOfPollutantsModel.WorkingHoursPerYear;
            ExistingSourceOfPollutants.AmountOfSOPWithOneNumber = SourceOfPollutantsModel.AmountOfSOPWithOneNumber;
            ExistingSourceOfPollutants.GasCleanerID = SourceOfPollutantsModel.GasCleanerID;
            ExistingSourceOfPollutants.StationaryIZAVID = SourceOfPollutantsModel.StationaryIZAVID;

            await _context.SaveChangesAsync();

            return ExistingSourceOfPollutants;
        }
    }
}
