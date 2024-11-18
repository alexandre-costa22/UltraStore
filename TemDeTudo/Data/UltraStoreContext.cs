using Microsoft.EntityFrameworkCore;
using UltraStore.Models;

namespace UltraStore.Data
{
    public class UltraStoreContext : DbContext
    {
        public UltraStoreContext(DbContextOptions<UltraStoreContext> options)
            : base(options)
        {
        }

        public DbSet<Product> Product { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<Client> Department { get; set; } = default!;
        public DbSet<SalesRecord> SalesRecord { get; set; } = default!;
    }
}
