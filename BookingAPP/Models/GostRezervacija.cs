using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPP.Models
{
    public class GostRezervacija
    {
        [Key, Column(Order = 0)]
        [ForeignKey("gost")]
        public int Gost { get; set; } // Pretpostavka je da se ovo podudara s nazivom stupca u bazi

        public Gost GostNavigation { get; set; } // Promijenjeno u GostNavigation

        [Key, Column(Order = 1)]
        [ForeignKey("rezervacija")]
        public int Rezervacija { get; set; } // Pretpostavka je da se ovo podudara s nazivom stupca u bazi

        public Rezervacija RezervacijaNavigation { get; set; } // Promijenjeno u RezervacijaNavigation
    }
}
