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
        public virtual DbSet<SourceOfPollutants> SourcesOfPollutants { get; set; }
        public virtual DbSet<SourceOfPollutants_Pollutant> SourcesOfPollutants_Pollutants { get; set; }
        public virtual DbSet<StationaryIZAV> StationaryIZAVs { get; set; }
        public virtual DbSet<StationaryIZAV_Pollutant> StationaryIZAVs_Pollutants { get; set; }
        public virtual DbSet<ModeOfIZAVWithNonStationaryEmissions> ModesOfIZAVWithNonStationaryEmissions { get; set; }
        public virtual DbSet<InstrumentalEmissionMeasuringOfSIZAV> InstrumentalEmissionMeasuringsOfSIZAV { get; set; }
        public virtual DbSet<InstrumentalEmissionMeasuringOfSIZAV_Pollutant> InstrumentalEmissionMeasuringsOfSIZAV_Pollutants { get; set; }
        public virtual DbSet<MobileIZAV> MobileIZAVs { get; set; }
        public virtual DbSet<MobileIZAV_Pollutant> MobileIZAVs_Pollutants { get; set; }
        public virtual DbSet<ResultOfGasCleanersInspection> ResultsOfGasCleanersInspection { get; set; }
        public virtual DbSet<ResultOfGasCleanersInspection_Pollutant> ResultsOfGasCleanersInspection_Pollutants { get; set; }
        public virtual DbSet<GasCleaner> GasCleaners { get; set; }
        public virtual DbSet<Pollutant> Pollutants { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasIndex(u => u.Login)
                .IsUnique(); // Указывает, что Username должен быть уникальным

            modelBuilder.Entity<SourceOfPollutants_Pollutant>()
                .HasKey(x => new { x.SourceOfPollutantsID, x.PollutantCode });

            modelBuilder.Entity<SourceOfPollutants_Pollutant>()
                .HasOne(x => x.SourceOfPollutants)
                .WithMany(s => s.SourcesOfPollutants_Pollutants)
                .HasForeignKey(x => x.SourceOfPollutantsID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<SourceOfPollutants_Pollutant>()
                .HasOne(x => x.Pollutant)
                .WithMany(p => p.SourcesOfPollutants_Pollutants)
                .HasForeignKey(x => x.PollutantCode)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<StationaryIZAV_Pollutant>()
                .HasKey(x => new { x.StationaryIZAVID, x.PollutantCode });

            modelBuilder.Entity<StationaryIZAV_Pollutant>()
                .HasOne(x => x.StationaryIZAV)
                .WithMany(s => s.StationaryIZAVs_Pollutants)
                .HasForeignKey(x => x.StationaryIZAVID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<StationaryIZAV_Pollutant>()
                .HasOne(x => x.Pollutant)
                .WithMany(p => p.StationaryIZAVs_Pollutants)
                .HasForeignKey(x => x.PollutantCode)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<InstrumentalEmissionMeasuringOfSIZAV_Pollutant>()
                .HasKey(x => new { x.InstrumentalEmissionMeasuringOfSIZAVID, x.PollutantCode });

            modelBuilder.Entity<InstrumentalEmissionMeasuringOfSIZAV_Pollutant>()
                .HasOne(x => x.InstrumentalEmissionMeasuringOfSIZAV)
                .WithMany(s => s.InstrumentalEmissionMeasuringsOfSIZAV_Pollutants)
                .HasForeignKey(x => x.InstrumentalEmissionMeasuringOfSIZAVID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<InstrumentalEmissionMeasuringOfSIZAV_Pollutant>()
                .HasOne(x => x.Pollutant)
                .WithMany(p => p.InstrumentalEmissionMeasuringsOfSIZAV_Pollutants)
                .HasForeignKey(x => x.PollutantCode)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<MobileIZAV_Pollutant>()
                .HasKey(x => new { x.MobileIZAVID, x.PollutantCode });

            modelBuilder.Entity<MobileIZAV_Pollutant>()
                .HasOne(x => x.MobileIZAV)
                .WithMany(s => s.MobileIZAVs_Pollutants)
                .HasForeignKey(x => x.MobileIZAVID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<MobileIZAV_Pollutant>()
                .HasOne(x => x.Pollutant)
                .WithMany(p => p.MobileIZAVs_Pollutants)
                .HasForeignKey(x => x.PollutantCode)
                .OnDelete(DeleteBehavior.NoAction);


            modelBuilder.Entity<ResultOfGasCleanersInspection_Pollutant>()
                .HasKey(x => new { x.ResultOfGasCleanersInspectionID, x.PollutantCode });

            modelBuilder.Entity<ResultOfGasCleanersInspection_Pollutant>()
                .HasOne(x => x.ResultOfGasCleanersInspection)
                .WithMany(s => s.ResultsOfGasCleanersInspection_Pollutants)
                .HasForeignKey(x => x.ResultOfGasCleanersInspectionID)
                .OnDelete(DeleteBehavior.NoAction);

            modelBuilder.Entity<ResultOfGasCleanersInspection_Pollutant>()
                .HasOne(x => x.Pollutant)
                .WithMany(p => p.ResultsOfGasCleanersInspection_Pollutants)
                .HasForeignKey(x => x.PollutantCode)
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}
