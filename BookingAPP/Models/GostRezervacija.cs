using System.ComponentModel.DataAnnotations.Schema;

namespace BookingAPP.Models
{
    public class Gostrezervacija
    {
        [ForeignKey("Gost")]
        public int GostId { get; set; }
        public virtual Gost Gost { get; set; }

        [ForeignKey("Rezervacija")]
        public int RezervacijaId { get; set; }
        public virtual Rezervacija Rezervacija { get; set; }
    }
}
