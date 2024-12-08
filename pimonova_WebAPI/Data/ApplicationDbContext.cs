using Microsoft.EntityFrameworkCore;
using pimonova_WebAPI.Models;

namespace pimonova_WebAPI.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
            
        }

        public virtual DbSet<Company> Companies { get; set; }
        public virtual DbSet<User> Users { get; set; }
        public virtual DbSet<ObjectOfNEI> ObjectsOfNEI { get; set; }
        public virtual DbSet<Workshop> Workshops { get; set; }
        public virtual DbSet<Sector> Sectors { get; set; }


    }
}
