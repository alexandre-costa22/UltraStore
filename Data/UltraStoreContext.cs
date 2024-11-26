using Microsoft.CodeAnalysis;
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
        public DbSet<Receipt> Nota { get; set; } = default!;
        public DbSet<Models.Software> Platforms { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Models.Software>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Game>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Client>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Seller>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Developer>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Franchise>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Receipt>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Publisher>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            //// Configuração para o relacionamento muitos-para-muitos entre Game e Platforms
            //modelBuilder.Entity<Game>()
            //    .HasMany(g => g.Platforms)
            //    .WithMany(p => p.Games)
            //    .UsingEntity<Dictionary<string, object>>(
            //        "GamePlatform", // Nome da tabela de junção
            //        j => j.HasOne<Platforms>().WithMany().HasForeignKey("PlatformId"),
            //        j => j.HasOne<Game>().WithMany().HasForeignKey("GameId")
            //    );

            // Configurações adicionais (opcional, para garantir que os nomes das tabelas sejam amigáveis)
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Seller>().ToTable("Sellers");
            modelBuilder.Entity<Developer>().ToTable("Developers");
            modelBuilder.Entity<Franchise>().ToTable("Franchises");
            modelBuilder.Entity<Game>().ToTable("Games");
            modelBuilder.Entity<Receipt>().ToTable("Notas");
            modelBuilder.Entity<Publisher>().ToTable("Publishers");
        }
    }
}
