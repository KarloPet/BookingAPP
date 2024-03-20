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


        public DbSet<User> Users { get; set; }



        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Rezervacija>()
                .HasMany(g => g.Gost)
                .WithMany(p => p.Rezervacije)
                .UsingEntity<Dictionary<string, object>>("gost_rezervacija",
                c => c.HasOne<Gost>().WithMany().HasForeignKey("gost"),
                c => c.HasOne<Rezervacija>().WithMany().HasForeignKey("rezervacija"),
                c => c.ToTable("gost_rezervacija")
                );
        }



    }
    }