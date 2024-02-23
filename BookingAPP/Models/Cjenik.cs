using System.ComponentModel.DataAnnotations;

namespace BookingAPP.Models
{
    public class Cjenik
    {
        public int Id { get; set; }
        public DateTime Datum { get; set; }
        public decimal Cijena { get; set; }
    }
}
