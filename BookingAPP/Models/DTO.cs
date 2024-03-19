// DTO.cs
namespace BookingAPP.Models
{

    public class RezervacijaDTORead
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }

        public RezervacijaDTORead(int id, decimal cijena, DateTime datumOd, DateTime datumDo)
        {
            Id = id;
            Cijena = cijena;
            DatumOd = datumOd;
            DatumDo = datumDo;
        }
        public RezervacijaDTORead()
        {
        }
    }

    public class RezervacijaDTOInsertUpdate
    {
        public int Id { get; set; }
        public decimal Cijena { get; set; }
        public DateTime DatumOd { get; set; }
        public DateTime DatumDo { get; set; }
        public List<GostDTORead> Gost { get; set; }

        public RezervacijaDTOInsertUpdate(int id, decimal cijena, DateTime datumOd, DateTime datumDo, List<GostDTORead> gost)
        {
            Id = id;
            Cijena = cijena;
            DatumOd = datumOd;
            DatumDo = datumDo;
            Gost = gost;
        }
        public RezervacijaDTOInsertUpdate()
        {
        }
    }

    public class GostDTORead
    {
        public int Id { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Oib { get; set; }

        public GostDTORead(int id, string? ime, string? prezime, string? oib)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Oib = oib;
        }
        public GostDTORead()
        {
        }
    }

    public class GostDTOInsertUpdate
    {
        public int Id { get; set; }
        public string? Ime { get; set; }
        public string? Prezime { get; set; }
        public string? Oib { get; set; }

        public GostDTOInsertUpdate(int id, string? ime, string? prezime, string? oib)
        {
            Id = id;
            Ime = ime;
            Prezime = prezime;
            Oib = oib;
        }
        public GostDTOInsertUpdate()
        {
        }
    }



    //public record RezervacijaDTORead(int id,decimal cijena, DateTime datumOd,
    //    DateTime datumDo);
    //// ako se parametar zove kao svojstvo nekog tipa u toj klasi tada uzima punu putanju klase (npr. EdunovaAPP.Models.Predavac)

    //public record RezervacijaDTOInsertUpdate(int id, decimal cijena, DateTime datumOd,
    //    DateTime datumDo, List<GostDTORead> Gost);


    //public record GostDTORead(int id, string? ime, string? prezime, string? oib);
    //public record GostDTOInsertUpdate(int id, string? ime, string? prezime, string? oib);
}

