using BookingAPP.Models;
namespace BookingAPP.Mappers
{
    public static class RezervacijaMapper
    {

        public static RezervacijaDTORead MapToDTORead(Rezervacija rezervacija)
        {
            return new RezervacijaDTORead
            { 
                Id = rezervacija.Id,
                Cijena = rezervacija.Cijena,
                DatumOd = rezervacija.Datum_Od,
                DatumDo = rezervacija.Datum_Do
            };
        }

        public static RezervacijaDTOInsertUpdate MapToDTOInsertUpdate(Rezervacija rezervacija)
        {
            List<GostDTORead> Gosti = new List<GostDTORead>();
            foreach (Gost gost in rezervacija.Gost)
            {
                Gosti.Add(GostMapper.ToDTO(gost));
            }

            return new RezervacijaDTOInsertUpdate
            {
                Id = rezervacija.Id,
                Cijena = rezervacija.Cijena,
                DatumOd = rezervacija.Datum_Od,
                DatumDo = rezervacija.Datum_Do,
                Gost = Gosti
            };
        }

    }
}


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