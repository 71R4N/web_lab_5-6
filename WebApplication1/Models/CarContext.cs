using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class CarContext : DbContext
    {
        public DbSet<Car> Car { get; set; }
        public CarContext(DbContextOptions<CarContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
