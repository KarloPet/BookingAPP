using BookingAPP.Models;
using Microsoft.EntityFrameworkCore;

namespace BookingAPP.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public DbSet<Cjenik> Cjenici { get; set; } // Ažurirajte prema vašim entitetima.
        public DbSet<Rezervacija> Rezervacije { get; set; }
        public DbSet<Gost> Gosti { get; set; }
        public DbSet<GostRezervacija> GostRezervacije { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Ovdje specificiramo ime tablice za svaki DbSet kako bi se poklapalo s onim u bazi.
            modelBuilder.Entity<Rezervacija>().ToTable("rezervacija");
            modelBuilder.Entity<Gost>().ToTable("gost");
            modelBuilder.Entity<GostRezervacija>().ToTable("gost_rezervacija");
            // Ponovite za svaki entitet kako bi se osiguralo da imena tablica odgovaraju.

            // Konfigurirajte primarne i složene ključeve, kao i veze.
            modelBuilder.Entity<Rezervacija>().HasKey(r => r.Id);
            modelBuilder.Entity<Gost>().HasKey(g => g.Id);
            modelBuilder.Entity<GostRezervacija>().HasKey(gr => new { gr.Gost, gr.Rezervacija });

            // Definiranje veza
            modelBuilder.Entity<GostRezervacija>()
                .HasOne(gr => gr.GostNavigation)
                .WithMany(g => g.GostRezervacije)
                .HasForeignKey(gr => gr.Gost);

            modelBuilder.Entity<GostRezervacija>()
                .HasOne(gr => gr.RezervacijaNavigation)
                .WithMany(r => r.GostRezervacije)
                .HasForeignKey(gr => gr.Rezervacija);
        }
    }
}
