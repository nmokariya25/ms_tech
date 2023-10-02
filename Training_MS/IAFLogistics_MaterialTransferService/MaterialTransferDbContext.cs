using IAFLogistics_MaterialTransferService.Models;
using Microsoft.EntityFrameworkCore;

namespace IAFLogistics_MaterialTransferService
{
    public class MaterialTransferDbContext : DbContext
    {
        public MaterialTransferDbContext(DbContextOptions<MaterialTransferDbContext> options) : base(options) { }

        public DbSet<MaterialTransfer> MaterialTransfers { get; set; }
    }
}