using Microsoft.EntityFrameworkCore;

namespace FinalGradeCalculatorWeb.Models
{
    public class MyDbContext : DbContext
    {
        public DbSet<Category> Categories { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase("MyDb");
        }
    }
}
