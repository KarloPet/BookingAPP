using AutoMapper;
using BookingAPP.Mappers;
using BookingAPP.Models;

namespace BookingAPP.Extensions
{
    public static class Mapping
    {
        //gost
        private static readonly Mapper GostReadMapper = GostMapper.InicijalizirajReadToDTO();
        private static readonly Mapper GostInsertUpdateMapper = GostMapper.InicijalizirajInsertUpdateFromDTO();

        // Ekstenzije za mapiranje Gost entiteta
        public static List<GostDTORead> MapGostReadList(this List<Gost> lista)
        {
            return lista.Select(g => GostReadMapper.Map<GostDTORead>(g)).ToList();
        }

        public static GostDTORead MapGostReadToDTO(this Gost entitet)
        {
            return GostReadMapper.Map<GostDTORead>(entitet);
        }

        public static Gost MapGostInsertUpdateFromDTO(this GostDTOInsertUpdate dto)
        {
            return GostInsertUpdateMapper.Map<Gost>(dto);
        }
        //cjenik
        private static readonly Mapper CjenikReadMapper = CjenikMapper.InicijalizirajReadToDTO();
        private static readonly Mapper CjenikInsertUpdateMapper = CjenikMapper.InicijalizirajInsertUpdateFromDTO();

        public static List<CjenaDTORead> MapCjenaReadList(this List<Cjenik> lista)
        {
            var vrati = lista.Select(e => CjenikReadMapper.Map<CjenaDTORead>(e)).ToList();
            return vrati;
        }

        public static CjenaDTORead MapCjenaReadToDTO(this Cjenik entitet)
        {
            return CjenikReadMapper.Map<CjenaDTORead>(entitet);
        }

        public static Cjenik MapCjenaInsertUpdateFromDTO(this CjenaDTOInsertUpdate dto)
        {
            return CjenikInsertUpdateMapper.Map<Cjenik>(dto);
        }


        //rezervacija
        private static readonly Mapper RezervacijaReadMapper = RezervacijaMapper.InicijalizirajReadToDTO();
        private static readonly Mapper RezervacijaInsertUpdateMapper = RezervacijaMapper.InicijalizirajInsertUpdateFromDTO();
        public static List<RezervacijaDTORead> MapRezervacijaReadList(this List<Rezervacija> lista)
        {
            var vrati = lista.Select(e => RezervacijaReadMapper.Map<RezervacijaDTORead>(e)).ToList();
            return vrati;
        }

        public static RezervacijaDTORead MapRezervacijaReadToDTO(this Rezervacija entitet)
        {
            return RezervacijaReadMapper.Map<RezervacijaDTORead>(entitet);
        }

        public static Rezervacija MapRezervacijaInsertUpdateFromDTO(this RezervacijaDTOInsertUpdate dto)
        {
            return RezervacijaInsertUpdateMapper.Map<Rezervacija>(dto);
        }
    }
}
