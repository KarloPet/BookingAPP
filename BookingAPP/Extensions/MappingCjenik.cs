//using BookingAPP.Mappers;
//using BookingAPP.Models;

//namespace BookingAPP.Extensions
//{
//        public static class MappingCjenik
//        {

//            public static List<CjenikDTORead> MapCjenikReadList(this List<Cjenik> lista)
//            {
//                var mapper = CjenikMapper.InicijalizirajReadToDTO();
//                var vrati = new List<CjenikDTORead>();
//                lista.ForEach(e => {
//                    vrati.Add(mapper.Map<CjenikDTORead>(e));
//                });
//                return vrati;
//            }

//            public static CjenikDTORead MapCjenikReadToDTO(this Cjenik entitet)
//            {
//                var mapper = CjenikMapper.InicijalizirajReadToDTO();
//                return mapper.Map<CjenikDTORead>(entitet);
//            }

//            public static CjenikDTOInsertUpdate MapCjenikInsertUpdatedToDTO(this Cjenik entitet)
//            {
//                var mapper = CjenikMapper.InicijalizirajInsertUpdateToDTO();
//                return mapper.Map<CjenikDTOInsertUpdate>(entitet);
//            }

//            public static Cjenik MapCjenikInsertUpdateFromDTO(this CjenikDTOInsertUpdate dto, Cjenik entitet)
//            {
//                entitet.Id = dto.id;
//                entitet.Datum = dto.datum;
//                entitet.Cijena = dto.cijena;
//                return entitet;
//            }
//        }
//}
