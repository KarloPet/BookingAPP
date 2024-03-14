//using BookingAPP.Mappers;
//using BookingAPP.Models;

//namespace BookingAPP.Extensions

//{
//        public static class MappingRezervacija
//        {

//            public static List<RezervacijaDTORead> MapRezervacijaReadList(this List<Rezervacija> lista)
//            {
//                var mapper = RezervacijaMapper.InicijalizirajReadToDTO();
//                var vrati = new List<RezervacijaDTORead>();
//                lista.ForEach(e => {
//                    vrati.Add(mapper.Map<RezervacijaDTORead>(e));
//                });
//                return vrati;
//            }

//            public static RezervacijaDTORead MapRezervacijaReadToDTO(this Rezervacija entitet)
//            {
//                var mapper = RezervacijaMapper.InicijalizirajReadToDTO();
//                return mapper.Map<RezervacijaDTORead>(entitet);
//            }

//            public static RezervacijaDTOInsertUpdate MapRezervacijaInsertUpdatedToDTO(this Rezervacija entitet)
//            {
//                var mapper = RezervacijaMapper.InicijalizirajInsertUpdateToDTO();
//                return mapper.Map<RezervacijaDTOInsertUpdate>(entitet);
//            }

//            public static Rezervacija MapRezervacijaInsertUpdateFromDTO(this RezervacijaDTOInsertUpdate dto, Rezervacija entitet)
//            {
//                entitet.Id = dto.id;
//                entitet.Cijena = dto.cijena;
//                entitet.Datum_Do = dto.datumdo;
//                entitet.Datum_Od = dto.datumod;
//                return entitet;
//            }
//        }
//}
