using IAFLogistic_DemandManagementService.Models;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;

namespace IAFLogistic_DemandManagementService
{
    public class DemandServiceDbContext : DbContext
    {
        public DemandServiceDbContext(DbContextOptions<DemandServiceDbContext> options) : base(options) { }

        public DbSet<DemandItem> DemandItems { get; set; }
    }
}