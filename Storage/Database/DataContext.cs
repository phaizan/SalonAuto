using Microsoft.EntityFrameworkCore;
using Storage.Models;

namespace Storage.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<Car> Cars { get; set; }
        public DbSet<Dealer> Dealers { get; set; }
        public DbSet<Customer> Customers { get; set; }
        public DbSet<CarCustomer> CarCustomers { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<CarCustomer>()
                .HasKey(cc => new { cc.CarId, cc.CustomerId });

            modelBuilder.Entity<CarCustomer>()
                .HasOne(cc => cc.Car)
                .WithMany(c => c.CarCustomers)
                .HasForeignKey(cc => cc.CarId);

            modelBuilder.Entity<CarCustomer>()
                .HasOne(cc => cc.Customer)
                .WithMany(c => c.CarCustomers)
                .HasForeignKey(cc => cc.CustomerId);
        }
    }
}
