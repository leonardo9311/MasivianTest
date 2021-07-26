using MasivianPrueba.Core.Entitiy;
using Microsoft.EntityFrameworkCore;

namespace MasivianPrueba.Infraestructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
          : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<Bet>(b => {
                b.HasKey(u => u.Id);

                b.ToTable("Bet");
            });
            modelBuilder.Entity<Roulette>(b => {
                b.HasKey(u => u.Id);

                b.ToTable("Roulette");
            });

        }
        public DbSet<Bet> Bet { get; set; }
        public DbSet<Roulette> Roulette { get; set; }
    }
}
