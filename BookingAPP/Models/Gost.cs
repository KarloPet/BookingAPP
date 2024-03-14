using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace BookingAPP.Models
{
    public class Gost
    {
        [Key]
        public int Id { get; set; }
        public string Ime { get; set; }
        public string Prezime { get; set; }
        public string Oib { get; set; }
        public List<GostRezervacija> GostRezervacije { get; set; }


    }
}
