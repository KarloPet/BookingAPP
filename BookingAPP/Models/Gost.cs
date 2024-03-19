using System.ComponentModel.DataAnnotations;

namespace BookingAPP.Models
{
    public class Gost
    {
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Oib { get; set; }

    }
}