using Microsoft.AspNetCore.Mvc.ApplicationModels;
using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.DTOs.StationaryIZAV;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;
using System.Xml.Linq;

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
            var StationaryIZAVModel = await _context.StationaryIZAVs.FirstOrDefaultAsync(x => x.StationaryIZAVID == Id);

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

        public Task<bool> StationaryIZAVExists(int Id)
        {
            return _context.StationaryIZAVs.AnyAsync(x => x.StationaryIZAVID == Id);
        }

        public async Task<StationaryIZAV> UpdateAsync(int Id, StationaryIZAV StationaryIZAVModel)
        {
            var ExistingStationaryIZAV = await _context.StationaryIZAVs.FindAsync(Id);

            if (ExistingStationaryIZAV == null)
            {
                return null;
            }

            ExistingStationaryIZAV.Type = StationaryIZAVModel.Type;
            ExistingStationaryIZAV.Name = StationaryIZAVModel.Name;
            ExistingStationaryIZAV.AmountOfIZAVWithOneNumber = StationaryIZAVModel.AmountOfIZAVWithOneNumber;
            ExistingStationaryIZAV.IZAVHeight = StationaryIZAVModel.IZAVHeight;
            ExistingStationaryIZAV.EstuaryDiameter = StationaryIZAVModel.EstuaryDiameter;
            ExistingStationaryIZAV.NumberInCompany = StationaryIZAVModel.NumberInCompany;
            ExistingStationaryIZAV.EstuaryLength = StationaryIZAVModel.EstuaryLength;
            ExistingStationaryIZAV.EstuaryWidth = StationaryIZAVModel.EstuaryWidth;
            ExistingStationaryIZAV.ArealZAVWidth = StationaryIZAVModel.ArealZAVWidth;
            ExistingStationaryIZAV.ModeNumber = StationaryIZAVModel.ModeNumber;
            ExistingStationaryIZAV.OutputSpeedOfGAM = StationaryIZAVModel.OutputSpeedOfGAM;
            ExistingStationaryIZAV.VolumeOfGAM = StationaryIZAVModel.VolumeOfGAM;
            ExistingStationaryIZAV.TemperatureOfGAM = StationaryIZAVModel.TemperatureOfGAM;
            ExistingStationaryIZAV.DensityOfGAM = StationaryIZAVModel.DensityOfGAM;

            await _context.SaveChangesAsync();

            return ExistingStationaryIZAV;
        }
    }
}
