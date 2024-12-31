using Microsoft.EntityFrameworkCore;

namespace WebApplication1.Models
{
    public class DilerContext : DbContext
    {
        public DbSet<Diler> Diler { get; set; }
        public DilerContext(DbContextOptions<DilerContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }
    }
}
