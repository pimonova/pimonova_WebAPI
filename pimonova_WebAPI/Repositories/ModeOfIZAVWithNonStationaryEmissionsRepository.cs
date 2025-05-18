using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.DTOs.ModeOfIZAVWithNonStationaryEmissions;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class ModeOfIZAVWithNonStationaryEmissionsRepository : IModeOfIZAVWithNonStationaryEmissionsRepository
    {
        private readonly ApplicationDbContext _context;
        public ModeOfIZAVWithNonStationaryEmissionsRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public Task<bool> ModeOfIZAVWithNonStationaryEmissionsExists(int Id)
        {
            return _context.ModesOfIZAVWithNonStationaryEmissions.AnyAsync(x => x.ModeID == Id);
        }

        public async Task<ModeOfIZAVWithNonStationaryEmissions> CreateAsync(ModeOfIZAVWithNonStationaryEmissions ModeOfIZAVWithNonStationaryEmissionsModel)
        {
            await _context.ModesOfIZAVWithNonStationaryEmissions.AddAsync(ModeOfIZAVWithNonStationaryEmissionsModel);
            await _context.SaveChangesAsync();

            return ModeOfIZAVWithNonStationaryEmissionsModel;
        }

        public async Task<ModeOfIZAVWithNonStationaryEmissions?> DeleteAsync(int Id)
        {
            var ModeOfIZAVWithNonStationaryEmissionsModel = await _context.ModesOfIZAVWithNonStationaryEmissions.FirstOrDefaultAsync(x => x.ModeID == Id);

            if (ModeOfIZAVWithNonStationaryEmissionsModel == null)
            {
                return null;
            }

            _context.ModesOfIZAVWithNonStationaryEmissions.Remove(ModeOfIZAVWithNonStationaryEmissionsModel);
            await _context.SaveChangesAsync();

            return ModeOfIZAVWithNonStationaryEmissionsModel;
        }

        public async Task<List<ModeOfIZAVWithNonStationaryEmissions>> GetAllAsync()
        {
            return await _context.ModesOfIZAVWithNonStationaryEmissions.ToListAsync();
        }

        public async Task<ModeOfIZAVWithNonStationaryEmissions?> GetByIdAsync(int Id)
        {
            return await _context.ModesOfIZAVWithNonStationaryEmissions.FindAsync(Id);
        }

        public async Task<ModeOfIZAVWithNonStationaryEmissions?> UpdateAsync(int Id, CreateOrUpdateModeOfIZAVWithNonStationaryEmissionsRequestDTO ModeOfIZAVWithNonStationaryEmissionsRequestDTO)
        {
            var ModeOfIZAVWithNonStationaryEmissions = await _context.ModesOfIZAVWithNonStationaryEmissions.FirstOrDefaultAsync(x => x.ModeID == Id);

            if (ModeOfIZAVWithNonStationaryEmissions == null)
            {
                return null;
            }

            ModeOfIZAVWithNonStationaryEmissions.ModeDescription = ModeOfIZAVWithNonStationaryEmissionsRequestDTO.ModeDescription;
            ModeOfIZAVWithNonStationaryEmissions.TimeOfWorking = ModeOfIZAVWithNonStationaryEmissionsRequestDTO.TimeOfWorking;
            ModeOfIZAVWithNonStationaryEmissions.ModeNumberInCompany = ModeOfIZAVWithNonStationaryEmissionsRequestDTO.ModeNumberInCompany;

            await _context.SaveChangesAsync();

            return ModeOfIZAVWithNonStationaryEmissions;
        }
    }
}
