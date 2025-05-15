using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class WorkshopRepository : IWorkshopRepository
    {
        private readonly ApplicationDbContext _context;
        public WorkshopRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<Workshop> CreateAsync(Workshop WorkshopModel)
        {
            await _context.Workshops.AddAsync(WorkshopModel);
            await _context.SaveChangesAsync();

            return WorkshopModel;
        }

        public async Task<Workshop?> DeleteAsync(int Id)
        {
            var WorkshopModel = await _context.Workshops.FirstOrDefaultAsync(x => x.WorkshopID == Id);

            if (WorkshopModel == null)
            {
                return null;
            }

            _context.Workshops.Remove(WorkshopModel);
            await _context.SaveChangesAsync();

            return WorkshopModel;
        }

        public async Task<List<Workshop>> GetAllAsync()
        {
            return await _context.Workshops.ToListAsync();
        }

        public async Task<Workshop?> GetByIdAsync(int Id)
        {
            return await _context.Workshops.FindAsync(Id);
        }

        public async Task<Workshop> UpdateAsync(int Id, Workshop WorkshopModel)
        {
            var ExistingWorkshop = await _context.Workshops.FindAsync(Id);

            if (ExistingWorkshop == null)
            {
                return null;
            }

            ExistingWorkshop.NumberInCompany = WorkshopModel.NumberInCompany;
            ExistingWorkshop.Name = WorkshopModel.Name;

            await _context.SaveChangesAsync();

            return ExistingWorkshop;
        }

        public Task<bool> WorkshopExists(int Id)
        {
            return _context.Workshops.AnyAsync(x => x.WorkshopID == Id);
        }
    }
}
