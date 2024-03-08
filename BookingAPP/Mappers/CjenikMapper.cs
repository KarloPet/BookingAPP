using BookingAPP.Models;
using AutoMapper;

namespace BookingAPP.Mappers
{
    public class CjenikMapper
    {
        public static Mapper InicijalizirajReadToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Cjenik, CjenaDTORead>();
                })
                );
        }

        public static Mapper InicijalizirajReadFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<CjenaDTORead, Cjenik>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateToDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<Cjenik, CjenaDTOInsertUpdate>();
                })
                );
        }

        public static Mapper InicijalizirajInsertUpdateFromDTO()
        {
            return new Mapper(
                new MapperConfiguration(c =>
                {
                    c.CreateMap<CjenaDTOInsertUpdate, Cjenik>();
                })
                );
        }

    }
}
