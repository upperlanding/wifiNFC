using Microsoft.EntityFrameworkCore;
using Wifi.Domain.Entity;

namespace Wifi.Infrastructure
{
    public class WifiContext : DbContext
    {
        public DbSet<Employee> Employee { get; set; } = default!;
        public DbSet<Room> Room { get; set; } = default!;
        public DbSet<Cleaning> Cleaning { get; set; } = default!;

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(ConString.ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            EmployeeSeed(modelBuilder);
        }

        void EmployeeSeed(ModelBuilder builder)
        {
            string[] users =
            {
                "peter", "martina", "orhan",
                "benjamin", "milos", "martind",
                "jan", "romana", "frederik",
                "romed"
            };

            for (int i = 0; i < users.Length; i++)
            {
                builder.Entity<Employee>().HasData(
                    new Employee()
                    {
                        Id = i+1,
                        Email = $"{users[i]}@mighty-putztrupp.at",
                        Password = "test1234"
                    });
            }

        }
    }
}