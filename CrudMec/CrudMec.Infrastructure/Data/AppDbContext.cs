using CrudMec.Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace CrudMec.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
     
      public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) {}

        public DbSet<Student> Students { get; set; }
        public DbSet<Teacher> Teachers { get; set; }
        public DbSet<Matter> Matters { get; set; }
        public DbSet<Registration> Registrations { get; set; }
        public DbSet<Login> Login { get; set; }

    }

    
}
