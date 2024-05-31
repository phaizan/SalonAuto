using Storage.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace Storage.Database
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {

        }
        public virtual DbSet<Center> Centers { get; set; }

        public virtual DbSet<User> Users { get; set; }


    }
}
