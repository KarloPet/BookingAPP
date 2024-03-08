using BookingAPP.Models;
using AutoMapper;

namespace BookingAPP.Mappers
{
    public class RezervacijaMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Rezervacija, RezervacijaDTORead>();
                })
                );
        }

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<RezervacijaDTORead, Rezervacija>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Rezervacija, RezervacijaDTOInsertUpdate>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<RezervacijaDTOInsertUpdate, Rezervacija>();
                })
                );
        }

    }
}
