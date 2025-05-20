using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.DTOs.InstrumentalEmissionMeasuring;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class InstrumentalEmissionMeasuringRepository : IInstrumentalEmissionMeasuringRepository
    {
        private readonly ApplicationDbContext _context;
        public InstrumentalEmissionMeasuringRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InstrumentalEmissionMeasuring> CreateAsync(InstrumentalEmissionMeasuring InstrumentalEmissionMeasuringModel)
        {
            await _context.InstrumentalEmissionMeasurings.AddAsync(InstrumentalEmissionMeasuringModel);
            await _context.SaveChangesAsync();

            return InstrumentalEmissionMeasuringModel;
        }

        public async Task<InstrumentalEmissionMeasuring?> DeleteAsync(int Id)
        {
            var InstrumentalEmissionMeasuringModel = await _context.InstrumentalEmissionMeasurings.FirstOrDefaultAsync(x => x.ResultID == Id);

            if (InstrumentalEmissionMeasuringModel == null)
            {
                return null;
            }

            _context.InstrumentalEmissionMeasurings.Remove(InstrumentalEmissionMeasuringModel);
            await _context.SaveChangesAsync();

            return InstrumentalEmissionMeasuringModel;
        }

        public async Task<List<InstrumentalEmissionMeasuring>> GetAllAsync()
        {
            return await _context.InstrumentalEmissionMeasurings.ToListAsync();
        }

        public async Task<InstrumentalEmissionMeasuring?> GetByIdAsync(int Id)
        {
            return await _context.InstrumentalEmissionMeasurings.FindAsync(Id);
        }

        public Task<bool> InstrumentalEmissionMeasuringExists(int Id)
        {
            return _context.InstrumentalEmissionMeasurings.AnyAsync(x => x.ResultID == Id);
        }

        public async Task<InstrumentalEmissionMeasuring> UpdateAsync(int Id, InstrumentalEmissionMeasuring InstrumentalEmissionMeasuringModel)
        {
            var ExistingInstrumentalEmissionMeasuring = await _context.InstrumentalEmissionMeasurings.FindAsync(Id);

            if (ExistingInstrumentalEmissionMeasuring == null)
            {
                return null;
            }

            ExistingInstrumentalEmissionMeasuring.DiameterOfWasteGas = InstrumentalEmissionMeasuringModel.DiameterOfWasteGas;
            ExistingInstrumentalEmissionMeasuring.SpeedOfWasteGas = InstrumentalEmissionMeasuringModel.SpeedOfWasteGas;
            ExistingInstrumentalEmissionMeasuring.VolumetricFlowRateOfWasteGasNC = InstrumentalEmissionMeasuringModel.VolumetricFlowRateOfWasteGasNC;
            ExistingInstrumentalEmissionMeasuring.TrueVolumetricFlowRateOfWasteGas = InstrumentalEmissionMeasuringModel.TrueVolumetricFlowRateOfWasteGas;
            ExistingInstrumentalEmissionMeasuring.TemperatureOfWasteGas = InstrumentalEmissionMeasuringModel.TemperatureOfWasteGas;
            ExistingInstrumentalEmissionMeasuring.PressureOfWasteGas = InstrumentalEmissionMeasuringModel.PressureOfWasteGas;
            ExistingInstrumentalEmissionMeasuring.WaterVaporConcentration = InstrumentalEmissionMeasuringModel.WaterVaporConcentration;

            await _context.SaveChangesAsync();

            return ExistingInstrumentalEmissionMeasuring;
        }
    }
}
