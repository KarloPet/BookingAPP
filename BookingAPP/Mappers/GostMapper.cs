using BookingAPP.Models; // Uključi svoje DTO klase

public class GostMapper
{
    public static GostDTORead ToDTO(Gost gost)
    {
        return new GostDTORead
        {
            Id = gost.Id,
            Ime = gost.Ime,
            Prezime = gost.Prezime,
            Oib = gost.Oib
        };
    }

    //public static Gost FromDTO(GostDTOInsertUpdate dto)
    //{
    //    return new Gost
    //    {
    //        Id = dto.id,
    //        Ime = dto.ime,
    //        Prezime = dto.prezime,
    //        Oib = dto.oib
    //    };
    //}
    //public static List<GostDTORead> FromDTO(List<GostDTOInsertUpdate> dtos)
    //{
    //    return dtos.Select(dto => new GostDTORead
    //    {
    //        id = dto.id,
    //        ime = dto.ime,
    //        prezime = dto.prezime,
    //        oib = dto.oib
    //    }).ToList();
    //}

}