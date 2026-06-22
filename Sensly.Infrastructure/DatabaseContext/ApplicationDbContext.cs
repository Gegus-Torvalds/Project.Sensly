using Microsoft.EntityFrameworkCore;
using Sensly.Core.Domain.Entities; 

namespace Sensly.Infrastructure.DatabaseContext
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Sensor> Sensors { get; set; }
        public DbSet<SensorReading> SensorReadings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<RefreshToken> RefreshTokens { get; set; }


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            System.Console.WriteLine("!!!   APPLICATION DB CONTEXT CREATED  !!!");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<UserRole>().HasKey((UserRole x) => new { x.RoleId, x.UserId });

        }
        
    }
}
