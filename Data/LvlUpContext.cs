using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using LvlUp.Models;

namespace LvlUp.Data
{
    public class LvlUpContext : IdentityDbContext<ApplicationUser>
    {
        public LvlUpContext(DbContextOptions<LvlUpContext> options)
            : base(options)
        {
        }

        public DbSet<Client> Client { get; set; } = default!;
        public DbSet<Seller> Seller { get; set; } = default!;
        public DbSet<Developer> Developer { get; set; } = default!;
        public DbSet<Franchise> Franchise { get; set; } = default!;
        public DbSet<Game> Game { get; set; } = default!;
        public DbSet<Receipt> Nota { get; set; } = default!;
        public DbSet<Software> Software { get; set; } = default!;
        public DbSet<Publisher> Publisher { get; set; } = default!;
        public DbSet<Cart> Cart { get; set; } = default;
        public DbSet<CartItem> CartItem { get; set; } = default;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Software>()
                .Property(p => p.Id)
                .ValueGeneratedOnAdd();

            modelBuilder.Entity<Game>()
                .Property(g => g.Id)
                .ValueGeneratedOnAdd();

            //modelBuilder.Entity<Game>()
            //    .HasOne(g => g.Software)  // Relacionamento de Game com Software
            //    .WithMany()               // Se Software tiver múltiplos Games
            //    .HasForeignKey(g => g.SoftwareId)  // Define a chave estrangeira
            //    .OnDelete(DeleteBehavior.Restrict);  // Define o comportamento de deleção

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

            // Configurações adicionais para as tabelas
            modelBuilder.Entity<Client>().ToTable("Clients");
            modelBuilder.Entity<Seller>().ToTable("Sellers");
            modelBuilder.Entity<Developer>().ToTable("Developers");
            modelBuilder.Entity<Franchise>().ToTable("Franchises");
            modelBuilder.Entity<Game>().ToTable("Games");
            modelBuilder.Entity<Receipt>().ToTable("Notas");
            modelBuilder.Entity<Publisher>().ToTable("Publishers");
            modelBuilder.Entity<Software>().ToTable("Software");  
        }

        public DbSet<Review>? Review { get; set; }
    }
}
