namespace BookingAPP.Models
{
    public class Rezervacija
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public DateTime Datum_Od { get; set; }
        public DateTime Datum_Do { get; set; }
    }

}
