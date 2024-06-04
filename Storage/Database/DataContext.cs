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
    }
}
