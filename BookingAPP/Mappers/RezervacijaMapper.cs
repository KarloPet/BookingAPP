using BookingAPP.Models;
namespace BookingAPP.Mappers
{
    public static class RezervacijaMapper
    {

        public static RezervacijaDTO MapToDTO(Rezervacija rezervacija)
        {
            return new RezervacijaDTO
            {
                Id = rezervacija.Id,
                Cijena = rezervacija.Cijena,
                DatumOd = rezervacija.Datum_Od,
                DatumDo = rezervacija.Datum_Do,
                Gosti = rezervacija.GostRezervacije.Select(gr => new GostDTO
                {
                    Id = gr.GostNavigation.Id,
                    Ime = gr.GostNavigation.Ime,
                    Prezime = gr.GostNavigation.Prezime,
                    Oib = gr.GostNavigation.Oib
                }).ToList()
            };
        }
    }
}

//using AutoMapper;
//using BookingAPP.Models;

//namespace BookingAPP.Mappers
//{ 
//    public class RezervacijaMapper
//    {
//        public static Mapper InicijalizirajReadToDTO()
//        {
//            return new Mapper(
//                new MapperConfiguration(c =>
//                {
//                    c.CreateMap<Rezervacija, RezervacijaDTORead>();
//                })
//                );
//        }

//        public static Mapper InicijalizirajReadFromDTO()
//        {
//            return new Mapper(
//                new MapperConfiguration(c =>
//                {
//                    c.CreateMap<RezervacijaDTORead, Rezervacija>();
//                })
//                );
//        }

//        public static Mapper InicijalizirajInsertUpdateToDTO()
//        {
//            return new Mapper(
//                new MapperConfiguration(c =>
//                {
//                    c.CreateMap<Rezervacija, RezervacijaDTOInsertUpdate>();
//                })
//                );
//        }
//    }
//}