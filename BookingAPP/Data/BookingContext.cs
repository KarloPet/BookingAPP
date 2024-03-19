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
        public DbSet<Cjenik> cjenik { get; set; }

        public DbSet<Rezervacija> rezervacija { get; set; }

        public DbSet<Gost> gost { get; set; }



    }
}