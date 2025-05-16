using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuringOfSIZAV;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class InstrumentalEmissionMeasuringOfSIZAVRepository : IInstrumentalEmissionMeasuringOfSIZAVRepository
    {
        private readonly ApplicationDbContext _context;
        public InstrumentalEmissionMeasuringOfSIZAVRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InstrumentalEmissionMeasuringOfSIZAV> CreateAsync(InstrumentalEmissionMeasuringOfSIZAV InstrumentalEmissionMeasuringOfSIZAVModel)
        {
            await _context.InstrumentalEmissionMeasuringsOfSIZAV.AddAsync(InstrumentalEmissionMeasuringOfSIZAVModel);
            await _context.SaveChangesAsync();

            return InstrumentalEmissionMeasuringOfSIZAVModel;
        }

        public async Task<InstrumentalEmissionMeasuringOfSIZAV?> DeleteAsync(int Id)
        {
            var InstrumentalEmissionMeasuringOfSIZAVModel = await _context.InstrumentalEmissionMeasuringsOfSIZAV.FirstOrDefaultAsync(x => x.ResultID == Id);

            if (InstrumentalEmissionMeasuringOfSIZAVModel == null)
            {
                return null;
            }

            _context.InstrumentalEmissionMeasuringsOfSIZAV.Remove(InstrumentalEmissionMeasuringOfSIZAVModel);
            await _context.SaveChangesAsync();

            return InstrumentalEmissionMeasuringOfSIZAVModel;
        }

        public async Task<List<InstrumentalEmissionMeasuringOfSIZAV>> GetAllAsync()
        {
            return await _context.InstrumentalEmissionMeasuringsOfSIZAV.ToListAsync();
        }

        public async Task<InstrumentalEmissionMeasuringOfSIZAV?> GetByIdAsync(int Id)
        {
            return await _context.InstrumentalEmissionMeasuringsOfSIZAV.FindAsync(Id);
        }

        public async Task<InstrumentalEmissionMeasuringOfSIZAV> UpdateAsync(int Id, InstrumentalEmissionMeasuringOfSIZAV InstrumentalEmissionMeasuringOfSIZAVModel)
        {
            var ExistingInstrumentalEmissionMeasuringOfSIZAV = await _context.InstrumentalEmissionMeasuringsOfSIZAV.FindAsync(Id);

            if (ExistingInstrumentalEmissionMeasuringOfSIZAV == null)
            {
                return null;
            }

            ExistingInstrumentalEmissionMeasuringOfSIZAV.DiameterOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVModel.DiameterOfWasteGas;
            ExistingInstrumentalEmissionMeasuringOfSIZAV.SpeedOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVModel.SpeedOfWasteGas;
            ExistingInstrumentalEmissionMeasuringOfSIZAV.VolumetricFlowRateOfWasteGasNC = InstrumentalEmissionMeasuringOfSIZAVModel.VolumetricFlowRateOfWasteGasNC;
            ExistingInstrumentalEmissionMeasuringOfSIZAV.TrueVolumetricFlowRateOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVModel.TrueVolumetricFlowRateOfWasteGas;
            ExistingInstrumentalEmissionMeasuringOfSIZAV.TemperatureOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVModel.TemperatureOfWasteGas;
            ExistingInstrumentalEmissionMeasuringOfSIZAV.PressureOfWasteGas = InstrumentalEmissionMeasuringOfSIZAVModel.PressureOfWasteGas;
            ExistingInstrumentalEmissionMeasuringOfSIZAV.WaterVaporConcentration = InstrumentalEmissionMeasuringOfSIZAVModel.WaterVaporConcentration;

            await _context.SaveChangesAsync();

            return ExistingInstrumentalEmissionMeasuringOfSIZAV;
        }
    }
}
