using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class InstrumentalEmissionMeasuring_PollutantRepository : IInstrumentalEmissionMeasuring_PollutantRepository
    {
        private readonly ApplicationDbContext _context;
        public InstrumentalEmissionMeasuring_PollutantRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<InstrumentalEmissionMeasuring_Pollutant> CreateAsync(InstrumentalEmissionMeasuring_Pollutant InstrumentalEmissionMeasuring_PollutantModel)
        {
            await _context.InstrumentalEmissionMeasurings_Pollutants.AddAsync(InstrumentalEmissionMeasuring_PollutantModel);
            await _context.SaveChangesAsync();

            return InstrumentalEmissionMeasuring_PollutantModel;
        }

        public async Task<InstrumentalEmissionMeasuring_Pollutant?> DeleteAsync(int InstrumentalEmissionMeasuringId, int PollutantId)
        {
            var InstrumentalEmissionMeasuring_PollutantModel = await _context.InstrumentalEmissionMeasurings_Pollutants.FirstOrDefaultAsync(x => x.InstrumentalEmissionMeasuringID == InstrumentalEmissionMeasuringId && x.PollutantID == PollutantId);

            if (InstrumentalEmissionMeasuring_PollutantModel == null)
            {
                return null;
            }

            _context.InstrumentalEmissionMeasurings_Pollutants.Remove(InstrumentalEmissionMeasuring_PollutantModel);
            await _context.SaveChangesAsync();

            return InstrumentalEmissionMeasuring_PollutantModel;
        }

        public async Task<List<InstrumentalEmissionMeasuring_Pollutant>> GetAllAsync()
        {
            return await _context.InstrumentalEmissionMeasurings_Pollutants.ToListAsync();
        }

        public async Task<InstrumentalEmissionMeasuring_Pollutant?> GetByIdAsync(int InstrumentalEmissionMeasuringId, int PollutantId)
        {
            return await _context.InstrumentalEmissionMeasurings_Pollutants.FirstOrDefaultAsync(x => x.InstrumentalEmissionMeasuringID == InstrumentalEmissionMeasuringId && x.PollutantID == PollutantId);
        }

        public async Task<InstrumentalEmissionMeasuring_Pollutant> UpdateAsync(int InstrumentalEmissionMeasuringId, int PollutantId, InstrumentalEmissionMeasuring_Pollutant StationaryIZAV_PollutantModel)
        {
            var ExistingInstrumentalEmissionMeasuring_Pollutant = await _context.InstrumentalEmissionMeasurings_Pollutants.FindAsync(InstrumentalEmissionMeasuringId, PollutantId);

            if (ExistingInstrumentalEmissionMeasuring_Pollutant == null)
            {
                return null;
            }

            ExistingInstrumentalEmissionMeasuring_Pollutant.InstrumentalEmissionMeasuringID = StationaryIZAV_PollutantModel.InstrumentalEmissionMeasuringID;
            ExistingInstrumentalEmissionMeasuring_Pollutant.PollutantID = StationaryIZAV_PollutantModel.PollutantID;
            ExistingInstrumentalEmissionMeasuring_Pollutant.MassConcentration = StationaryIZAV_PollutantModel.MassConcentration;
            ExistingInstrumentalEmissionMeasuring_Pollutant.PollutantEmission = StationaryIZAV_PollutantModel.PollutantEmission;
            ExistingInstrumentalEmissionMeasuring_Pollutant.MeanPollutantEmission = StationaryIZAV_PollutantModel.MeanPollutantEmission;
            ExistingInstrumentalEmissionMeasuring_Pollutant.MaxPollutantEmission = StationaryIZAV_PollutantModel.MaxPollutantEmission;
            ExistingInstrumentalEmissionMeasuring_Pollutant.MeasuringMethod = StationaryIZAV_PollutantModel.MeasuringMethod;

            await _context.SaveChangesAsync();

            return ExistingInstrumentalEmissionMeasuring_Pollutant;
        }
    }
}
