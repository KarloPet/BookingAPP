using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPP.Models
{
    public class GostRezervacija
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("gost")]
        public Gost Gost { get; set; }

        [ForeignKey("rezervacija")]
        public Rezervacija Rezervacija { get; set; }

    }

}