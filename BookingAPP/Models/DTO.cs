namespace BookingAPP.Models
{
    //rezervacija
    //public record RezervacijaDTORead(int id, decimal cijena, DateTime datum_od,
    //    DateTime datum_do, List<GostDTORead> Gosti);
    //public record RezervacijaDTORead(int id, decimal cijena, DateTime datum_od,
    //    DateTime datum_do, List<GostDTORead> Gosti);
    public class RezervacijaDTORead
    {
        public int id { get; set; }
        public decimal cijena { get; set; }
        public DateTime datum_od { get; set; }
        public DateTime datum_do { get; set; }
        public List<GostDTORead> Gosti { get; set; }
    }



        public record RezervacijaDTOInsertUpdate(int id, decimal cijena, DateTime datum_od,
        DateTime datum_do, List<GostDTOInsertUpdate> Gosti);
    //cjena
    public record CjenaDTORead (int id, DateTime datum, decimal cijena);
    public record CjenaDTOInsertUpdate(int id, DateTime datum, decimal cijena);
    //gost
   // public record GostDTORead

    public class GostDTORead
    {
        public int id { get; set; }
        public string ime { get; set; }
        public string prezime { get; set; }
        public string oib { get; set; }
    }
    public record GostDTOInsertUpdate(int id, string ime, string prezime, string oib);//, List<RezervacijaDTOInsertUpdate> Rezervacije);



    //na liniji 12 i 13 sam zakomentirao jer mi onda poziva više puta istu listu gostiju


    //public record GostDTORead(int id, string ime, string prezime, int oib);
    //public record GostDTOInsertUpdate(int id, string ime, string prezime, int oib);


}
