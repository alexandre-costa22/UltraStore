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

        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<Developer> Developer { get; set; } = default!;
        public DbSet<Franchise> Franchise { get; set; } = default!;
        public DbSet<Game> Game { get; set; } = default!;
        public DbSet<Nota> Nota { get; set; } = default!;
        public DbSet<Platforms> Platforms { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;

    }
}
