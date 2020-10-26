using Microsoft.EntityFrameworkCore;

namespace Parking.Data
{
    public class StoreDataContext : DbContext
    {
        public StoreDataContext (DbContextOptions<StoreDataContext> options)
            : base(options)
        {
        }

        public DbSet<Parking.Models.PriceTable> PriceTable { get; set; }

        public DbSet<Parking.Models.ParkingDrive> ParkingDrive { get; set; }
        
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Parking.Models.PriceTable>().ToTable("PriceTable");
            modelBuilder.Entity<Parking.Models.ParkingDrive>().ToTable("ParkingDrive");
        }   
    }
}
