using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Data;
using pimonova_WebAPI.Interfaces;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Repositories
{
    public class ObjectOfNEIRepository : IObjectOfNEIRepository
    {
        private readonly ApplicationDbContext _context;
        public ObjectOfNEIRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public async Task<ObjectOfNEI> CreateAsync(ObjectOfNEI ObjectOfNEIModel)
        {
            await _context.ObjectsOfNEI.AddAsync(ObjectOfNEIModel);
            await _context.SaveChangesAsync();

            return ObjectOfNEIModel;
        }

        public async Task<ObjectOfNEI?> DeleteAsync(int Id)
        {
            var ObjectOfNEIModel = await _context.ObjectsOfNEI.FirstOrDefaultAsync(x => x.ObjectOfNEIID == Id);

            if (ObjectOfNEIModel == null)
            {
                return null;
            }

            _context.ObjectsOfNEI.Remove(ObjectOfNEIModel);
            await _context.SaveChangesAsync();

            return ObjectOfNEIModel;
        }

        public async Task<List<ObjectOfNEI>> GetAllAsync()
        {
            return await _context.ObjectsOfNEI.ToListAsync();
        }

        public async Task<ObjectOfNEI?> GetByIdAsync(int Id)
        {
            return await _context.ObjectsOfNEI.FindAsync(Id);
        }

        public async Task<ObjectOfNEI> UpdateAsync(int Id, ObjectOfNEI ObjectOfNEIModel)
        {
            var ExistingObjectOfNEI = await _context.ObjectsOfNEI.FindAsync(Id);

            if (ExistingObjectOfNEI == null)
            {
                return null;
            }

            ExistingObjectOfNEI.Name = ObjectOfNEIModel.Name;
            ExistingObjectOfNEI.LocationAddress = ObjectOfNEIModel.LocationAddress;
            ExistingObjectOfNEI.Category = ObjectOfNEIModel.Category;

            await _context.SaveChangesAsync();

            return ExistingObjectOfNEI;
        }
    }
}
