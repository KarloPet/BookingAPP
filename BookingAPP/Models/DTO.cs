using BookingAPP.Models;

public class RezervacijaDTO
{
    public int Id { get; set; }
    public decimal Cijena { get; set; }
    public DateTime DatumOd { get; set; }
    public DateTime DatumDo { get; set; }
    public List<GostDTO> Gosti { get; set; } // Lista DTO-a umjesto entiteta
}

public class GostDTO
{
    public int Id { get; set; }
    public string Ime { get; set; }
    public string Prezime { get; set; }
    public string Oib { get; set; }
}






//namespace BookingAPP.Models
//{

//    public record CjenikDTORead(int id, DateTime datum, decimal cijena);

//    public record CjenikDTOInsertUpdate(int id, DateTime datum, decimal cijena);



//    public record RezervacijaDTORead(int id, decimal cijena, DateTime datumod,
//    DateTime datumdo);

//    public record RezervacijaDTOInsertUpdate(int id, decimal cijena, DateTime datumod,
//    DateTime datumdo);


//    //public class RezervacijaDTORead
//    //{
//    //    public int id { get; set; }
//    //    public decimal cijena { get; set; }
//    //    public DateTime datum_od { get; set; }
//    //    public DateTime datum_do { get; set; }
//    //    public List<GostDTORead> Gosti { get; set; }
//    //}

//    //public class RezervacijaDTOInsertUpdate
//    //{
//    //    public int id { get; set; }
//    //    public decimal cijena { get; set; }
//    //    public DateTime datum_od { get; set; }
//    //    public DateTime datum_do { get; set; }

//    //    public List<GostDTOInsertUpdate> Gosti { get; set; }
//    //}
//    //public class GostDTORead
//    //{
//    //    public int id { get; set; }
//    //    public string ime { get; set; }
//    //    public string prezime { get; set; }
//    //    public string oib { get; set; }

//    //}
//    //public class GostDTOInsertUpdate
//    //{
//    //    public int id { get; set; }
//    //    public string ime { get; set; }
//    //    public string prezime { get; set; }
//    //    public string oib { get; set; }

//    //}
//}
