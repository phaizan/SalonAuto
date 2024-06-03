using Microsoft.EntityFrameworkCore.Design;
using Storage.Database;
using Microsoft.EntityFrameworkCore;

namespace Storage.MS_SQL
{
    public class SqlServerContextFactory : IDesignTimeDbContextFactory<DataContext>
    {
        private const string DbContextString = "Server=localhost,1433;Database=AutoSalon;User ID=sa;Password=pR0$touzhedaitemnepultOtyanderki;MultipleActiveResultSets=true;TrustServerCertificate=True";

        public DataContext CreateDbContext(string[] args)
        {
            var optionBuilder = new DbContextOptionsBuilder<DataContext>();
            optionBuilder.UseSqlServer(DbContextString, b => b.MigrationsAssembly(typeof(SqlServerContextFactory).Namespace));

            return new DataContext(optionBuilder.Options);
        }
    }

}
