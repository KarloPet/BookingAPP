//// Mapping.cs
//using AutoMapper;
//using BookingAPP.Models;

//namespace BookingAPP.Extensions
//{
//    public class AutoMapperProfile : Profile
//    {
//        public AutoMapperProfile()
//        {
//            CreateMap<Gost, GostDTO>();
//            CreateMap<Rezervacija, RezervacijaDTO>();
//            // Ako želite uključiti listu GostDTO unutar RezervacijaDTO za svaku Rezervaciju
//            CreateMap<Rezervacija, RezervacijaDTO>()
//                .ForMember(dest => dest.Gosti, opt => opt.MapFrom(src => src.GostRezervacije.Select(gr => gr.GostNavigation)));

//            CreateMap<GostRezervacija, GostRezervacijaDTO>()
//                .ForMember(dest => dest.GostId, opt => opt.MapFrom(src => src.Gost))
//                .ForMember(dest => dest.RezervacijaId, opt => opt.MapFrom(src => src.Rezervacija));
//        }
//    }


//}

