using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
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
            throw new NotImplementedException();
        }

        public async Task<SourceOfPollutants?> DeleteAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<SourceOfPollutants>> GetAllAsync()
        {
            throw new NotImplementedException();
        }

        public async Task<SourceOfPollutants?> GetByIdAsync(int Id)
        {
            throw new NotImplementedException();
        }

        public async Task<SourceOfPollutants> UpdateAsync(int Id, SourceOfPollutants SourceOfPollutantsModel)
        {
            throw new NotImplementedException();
        }
    }
}
