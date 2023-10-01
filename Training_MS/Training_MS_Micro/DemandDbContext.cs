using Microsoft.EntityFrameworkCore;
using Training_MS_Micro.Models;

namespace Training_MS_Micro
{
    public class DemandDbContext : DbContext
    {
        public DemandDbContext(DbContextOptions<DemandDbContext> options) : base(options) { }

        public DbSet<DemandItem> DemandItems { get; set; }
    }
}
