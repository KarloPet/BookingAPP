using BookingAPP.Models;

public static class Mapping
{
    public static RezervacijaDTO ToDto(this Rezervacija rezervacija)
    {
        return new RezervacijaDTO
        {
            Id = rezervacija.Id,
            Cijena = rezervacija.Cijena,
            DatumOd = rezervacija.Datum_Od,
            DatumDo = rezervacija.Datum_Do,
            // Pretpostavljamo da RezervacijaDTO sadrži popis gostiju kao DTO
            Gosti = rezervacija.GostRezervacije?
                        .Select(gr => gr.Gost.ToDto())
                        .ToList()
        };
    }

    public static GostDTO ToDto(this Gost gost)
    {
        return new GostDTO
        {
            Id = gost.Id,
            Ime = gost.Ime,
            Prezime = gost.Prezime,
            Oib = gost.Oib
            // Ostala svojstva ako su potrebna
        };
    }

    // Dodajte dodatne metode za mapiranje drugih entiteta ako je potrebno
}

//using AutoMapper;
//using BookingAPP.Mappers;
//using BookingAPP.Models;

//namespace BookingAPP.Extensions
//{
//    public class Mapping : Profile
//    {
//        public Mapping()
//        {
//            // Mapiranje od entiteta Rezervacija na RezervacijaDTORead.
//            CreateMap<Rezervacija, RezervacijaDTORead>()
//                .ForMember(dest => dest.Gosti, act => act.MapFrom(src => src.GostRezervacije.Select(gr => gr.Gost)));

//            // Mapiranje od RezervacijaDTOInsertUpdate na entitet Rezervacija.
//            // Obratite pažnju da ovdje ne morate mapirati id jer se on obično generira u bazi podataka.
//            CreateMap<RezervacijaDTOInsertUpdate, Rezervacija>()
//                .ForMember(dest => dest.GostRezervacije, act => act.MapFrom(src => src.Gosti));

//            // Slično dodajte mapiranja za goste, gost_rezervacija i cjenik ako je potrebno.
//            CreateMap<Gost, GostDTORead>();
//            CreateMap<GostDTOInsertUpdate, Gost>();

//            // Kada mapirate kolekciju entiteta na DTO, koristite Select kako biste mapirali svaki element.
//            // CreateMap<ICollection<GostRezervacija>, List<GostDTORead>>()
//            //    .ConvertUsing(src => src.Select(x => new GostDTORead { ... }).ToList());
//        }
//    }


























//    ////gost
//    //private static readonly Mapper GostReadMapper = GostMapper.InicijalizirajReadToDTO();
//    //private static readonly Mapper GostInsertUpdateMapper = GostMapper.InicijalizirajInsertUpdateFromDTO();

//    //// Ekstenzije za mapiranje Gost entiteta
//    //public static List<GostDTORead> MapGostReadList(this List<Gost> lista)
//    //{
//    //    return lista.Select(g => GostReadMapper.Map<GostDTORead>(g)).ToList();
//    //}

//    //public static GostDTORead MapGostReadToDTO(this Gost entitet)
//    //{
//    //    return GostReadMapper.Map<GostDTORead>(entitet);
//    //}

//    //public static Gost MapGostInsertUpdateFromDTO(this GostDTOInsertUpdate dto)
//    //{
//    //    return GostInsertUpdateMapper.Map<Gost>(dto);
//    //}
//    ////cjenik
//    //private static readonly Mapper CjenikReadMapper = CjenikMapper.InicijalizirajReadToDTO();
//    //private static readonly Mapper CjenikInsertUpdateMapper = CjenikMapper.InicijalizirajInsertUpdateFromDTO();

//    //public static List<CjenaDTORead> MapCjenaReadList(this List<Cjenik> lista)
//    //{
//    //    var vrati = lista.Select(e => CjenikReadMapper.Map<CjenaDTORead>(e)).ToList();
//    //    return vrati;
//    //}

//    //public static CjenaDTORead MapCjenaReadToDTO(this Cjenik entitet)
//    //{
//    //    return CjenikReadMapper.Map<CjenaDTORead>(entitet);
//    //}

//    //public static Cjenik MapCjenaInsertUpdateFromDTO(this CjenaDTOInsertUpdate dto)
//    //{
//    //    return CjenikInsertUpdateMapper.Map<Cjenik>(dto);
//    //}


//    ////rezervacija
//    //private static readonly Mapper RezervacijaReadMapper = RezervacijaMapper.InicijalizirajReadToDTO();
//    //private static readonly Mapper RezervacijaInsertUpdateMapper = RezervacijaMapper.InicijalizirajInsertUpdateFromDTO();
//    //public static List<RezervacijaDTORead> MapRezervacijaReadList(this List<Rezervacija> lista)
//    //{
//    //    var vrati = lista.Select(e => RezervacijaReadMapper.Map<RezervacijaDTORead>(e)).ToList();
//    //    return vrati;
//    //}

//    //public static RezervacijaDTORead MapRezervacijaReadToDTO(this Rezervacija entitet)
//    //{
//    //    //return RezervacijaReadMapper.Map<RezervacijaDTORead>(entitet);
//    //    var dto = RezervacijaReadMapper.Map<RezervacijaDTORead>(entitet);
//    //    // Pretpostavimo da vaš GostRezervacija entitet ima navigacijsko svojstvo 'Gost' koje treba mapirati
//    //    dto.Gosti = entitet.GostRezervacije.Select(gr => gr.Gost.MapGostReadToDTO()).ToList();
//    //    return dto;
//    //}

//    //public static Rezervacija MapRezervacijaInsertUpdateFromDTO(this RezervacijaDTOInsertUpdate dto)
//    //{
//    //    return RezervacijaInsertUpdateMapper.Map<Rezervacija>(dto);
//    //}
//}

