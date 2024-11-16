using Microsoft.EntityFrameworkCore;
using Task.Models;

namespace Task.Data
{
    public class ApplicationDbContext : DbContext 
    {
        public ApplicationDbContext( DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Student>().HasIndex(s => s.Price).IsUnique();


        }

        public DbSet<Employee> Employees { get; set; }
        public DbSet<Department> Departments { get; set; }
        public DbSet<Student> Students { get; set; }
    }
}
