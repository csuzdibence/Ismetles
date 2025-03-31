using Microsoft.EntityFrameworkCore;

namespace Ismetles.Models
{
    public class ValamilyenDbContext : DbContext
    {
        public DbSet<UserFormModel> UserFormModels { get; set; }

        public ValamilyenDbContext()
        {
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Server=(localdb)\\MSSQLLocalDb;Database=UserFormModelDatabase");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<UserFormModel>().HasData(new UserFormModel()
            {
                Id = 1,
                Username = "asd",
                Email = "asd@gmail.com"
            });
        }
    }
}