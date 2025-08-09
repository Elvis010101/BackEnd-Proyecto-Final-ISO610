using Microsoft.EntityFrameworkCore;

namespace BackEndProyectoFinalIso610.DATA
{
    // Ensure AppDbContext inherits from DbContext
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        // Define DbSets for your entities here
        // Example: public DbSet<YourEntity> YourEntities { get; set; }
    }
}
