using Domain.Entities;
using Infrastructure.DbConfig;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
    public class ApplicationContext : DbContext, IApplicationContext
    {
        public ApplicationContext() { }

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
          : base(options)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TruckModel>().HasData(TruckModelSeed.Seeds);
            modelBuilder.Entity<Truck>().HasData(TruckSeed.Seeds);

            base.OnModelCreating(modelBuilder);
        }

        protected override void OnConfiguring(DbContextOptionsBuilder dbContextOptionsBuilder)
        {
            if (!dbContextOptionsBuilder.IsConfigured)
                dbContextOptionsBuilder.UseSqlServer(DatabaseConnection.GetConnection());
        }

        public void CreateDatabaseOnStart()
        {
            Database.Migrate();
        }

        public DbSet<Truck> Truck { get; set; }
        public DbSet<TruckModel> TruckModel { get; set; }
    }
}
