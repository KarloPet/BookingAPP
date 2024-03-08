using System.ComponentModel.DataAnnotations;

namespace BookingAPP.Models
{
    public class Rezervacija
    {
        [Key]
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public DateTime Datum_Od { get; set; }
        public DateTime Datum_Do { get; set; }

        public ICollection<Gostrezervacija> GostRezervacije { get; set; }
    }

}
