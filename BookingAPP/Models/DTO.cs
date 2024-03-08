namespace BookingAPP.Models
{
    //rezervacija
    public record RezervacijaDTORead(int id, decimal cijena, DateTime datum_od,
        DateTime datum_do, List<GostDTORead> Gosti);
    public record RezervacijaDTOInsertUpdate(int id, decimal cijena, DateTime datum_od,
        DateTime datum_do, List<GostDTOInsertUpdate> Gosti);
    //cjena
    public record CjenaDTORead (int id, DateTime datum, decimal cijena);
    public record CjenaDTOInsertUpdate(int id, DateTime datum, decimal cijena);
    //gost
    public record GostDTORead(int id, string ime, string prezime, string oib);//, List<RezervacijaDTORead> Rezervacije);
    public record GostDTOInsertUpdate(int id, string ime, string prezime, string oib);//, List<RezervacijaDTOInsertUpdate> Rezervacije);


    //public record GostDTORead(int id, string ime, string prezime, int oib);
    //public record GostDTOInsertUpdate(int id, string ime, string prezime, int oib);


}
