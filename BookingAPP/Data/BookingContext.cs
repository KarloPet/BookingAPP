using BookingAPP.Models;
using Microsoft.EntityFrameworkCore;
using System.Text.RegularExpressions;

namespace BookingAPP.Data
{
    public class BookingContext : DbContext
    {
        public BookingContext(DbContextOptions<BookingContext> options)
            : base(options)
        {
        }

        public DbSet<Cjenik> cjenik { get; set; }
        public DbSet<Rezervacija> rezervacija { get; set; }
        public DbSet<Gost> gost { get; set; }
        public DbSet<Gostrezervacija> GostRezervacije { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Gostrezervacija>()
                .HasKey(gr => new { gr.GostId, gr.RezervacijaId });

        }
    }
}
