using BookingAPP.Models;
using AutoMapper;

namespace BookingAPP.Mappers
{
    public class GostMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Gost, GostDTORead>();
                })
            );
        }

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<GostDTORead, Gost>();
                })
            );
        }

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Gost, GostDTOInsertUpdate>();
                })
            );
        }

        public static Mapper InicijalizirajInsertUpdateFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<GostDTOInsertUpdate, Gost>();
                })
            );
        }
    }
}
