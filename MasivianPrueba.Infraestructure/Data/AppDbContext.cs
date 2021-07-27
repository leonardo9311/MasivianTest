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
                b.Property(u => u.amount).HasColumnName("Amount");
                b.Property(u=>u.idUser).HasColumnName("IdUser");
                b.Property(u => u.number).HasColumnName("Number");
                b.Property(u => u.idRoullette).HasColumnName("IdRoulette");
                b.HasOne(br=>br.Roulette).WithMany(r=>r.bets).HasForeignKey(br=>br.idRoullette);
                b.Ignore(u=>u.Roulette);
                b.ToTable("Bet");
            });
            modelBuilder.Entity<Roulette>(b => {
                b.HasKey(u => u.Id);
                b.Property(u=>u.isOpen).HasColumnName("IsOpen");
                
                b.Ignore(u => u.bets);
                b.ToTable("Roulette");
            });

        }
        public DbSet<Bet> Bet { get; set; }
        public DbSet<Roulette> Roulette { get; set; }
    }
}
