using Microsoft.EntityFrameworkCore;
using Training_MS_Mono.Models;

namespace Training_MS_Mono
{
    public class IAFLogisticsContext : DbContext
    {
        public IAFLogisticsContext(DbContextOptions<IAFLogisticsContext> options) : base(options) { }

        public DbSet<DemandItem> DemandItems { get; set; }
        public DbSet<TransferRequest> TransferRequests { get; set; }
    }
}
