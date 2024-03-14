using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using BookingAPP.Data;
using BookingAPP.Models;

[Route("api/[controller]")]
[ApiController]
public class RezervacijaController : ControllerBase
{
    private readonly BookingContext _context;

    public RezervacijaController(BookingContext context)
    {
        _context = context;
    }

    // GET: api/Rezervacija
    [HttpGet]
    public async Task<ActionResult<IEnumerable<RezervacijaDTO>>> GetAllRezervacije()
    {
        var rezervacije = await _context.Rezervacije
            .Include(r => r.GostRezervacije)
                .ThenInclude(gr => gr.Gost)
            .ToListAsync();

        // Ovdje biste mapirali rezultate u DTO, pretpostavljajući da imate metodu za to
        var rezervacijeDto = rezervacije.Select(r => r.ToDto());

        return Ok(rezervacijeDto);
    }

}



//using BookingAPP.Data;
//using BookingAPP.Extensions;
//using BookingAPP.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace BookingAPP.Controllers
//{

//    [ApiController]
//    [Route("api/v1/[controller]")]
//    public class RezervacijaController : ControllerBase
//    {

//        private readonly BookingContext _context;

//        public RezervacijaController(BookingContext context)
//        {
//            _context = context;
//        }


//        [HttpGet]
//        public IActionResult Get()
//        {
//            // kontrola ukoliko upit nije valjan
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            try
//            {
//                var lista = _context.Rezervacije.ToList();
//                if (lista == null || lista.Count == 0)
//                {
//                    return new EmptyResult();
//                }
//                return new JsonResult(lista.MapRezervacijaReadList());
//            }
//            catch (Exception ex)
//            {
//                return StatusCode(StatusCodes.Status503ServiceUnavailable,
//                    ex.Message);
//            }
//        }

//        //[HttpGet]
//        //[Route("{id:int}")]
//        //public IActionResult GetByid(int id)
//        //{
//        //    // kontrola ukoliko upit nije valjan
//        //    if (!ModelState.IsValid || id <= 0)
//        //    {
//        //        return BadRequest(ModelState);
//        //    }
//        //    try
//        //    {
//        //        var p = _context.Rezervacije.Find(id);
//        //        if (p == null)
//        //        {
//        //            return new EmptyResult();
//        //        }
//        //        return new JsonResult(p.MapRezervacijaInsertUpdatedToDTO());
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(StatusCodes.Status503ServiceUnavailable,
//        //            ex.Message);
//        //    }
//        //}


//        //[HttpPost]
//        //public IActionResult Post(RezervacijaDTOInsertUpdate dto)
//        //{
//        //    if (!ModelState.IsValid || dto == null)
//        //    {
//        //        return BadRequest();
//        //    }
//        //    try
//        //    {
//        //        var entitet = dto.MapRezervacijaInsertUpdateFromDTO(new Rezervacija());
//        //        _context.Rezervacije.Add(entitet);
//        //        _context.SaveChanges();
//        //        return StatusCode(StatusCodes.Status201Created, entitet.MapRezervacijaReadToDTO());
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(StatusCodes.Status503ServiceUnavailable,
//        //            ex.Message);
//        //    }
//        //}


//        //[HttpPut]
//        //[Route("{id:int}")]
//        //public IActionResult Put(int id, RezervacijaDTOInsertUpdate dto)
//        //{
//        //    if (id <= 0 || !ModelState.IsValid || dto == null)
//        //    {
//        //        return BadRequest();
//        //    }


//        //    try
//        //    {


//        //        var entitetIzBaze = _context.Rezervacije.Find(id);

//        //        if (entitetIzBaze == null)
//        //        {
//        //            return StatusCode(StatusCodes.Status204NoContent, id);
//        //        }

//        //        var entitet = dto.MapRezervacijaInsertUpdateFromDTO(entitetIzBaze);

//        //        _context.Rezervacije.Update(entitetIzBaze);
//        //        _context.SaveChanges();

//        //        return StatusCode(StatusCodes.Status200OK, entitetIzBaze.MapRezervacijaInsertUpdatedToDTO());
//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(StatusCodes.Status503ServiceUnavailable,
//        //            ex.Message);
//        //    }

//        //}


//        //[HttpDelete]
//        //[Route("{id:int}")]
//        //[Produces("application/json")]
//        //public IActionResult Delete(int id)
//        //{
//        //    if (!ModelState.IsValid || id <= 0)
//        //    {
//        //        return BadRequest();
//        //    }

//        //    try
//        //    {
//        //        var entitetIzbaze = _context.Rezervacije.Find(id);

//        //        if (entitetIzbaze == null)
//        //        {
//        //            return StatusCode(StatusCodes.Status204NoContent, id);
//        //        }

//        //        _context.Rezervacije.Remove(entitetIzbaze);
//        //        _context.SaveChanges();

//        //        return new JsonResult(new { poruka = "Obrisano" }); // ovo nije baš najbolja praksa ali da znake kako i to može

//        //    }
//        //    catch (Exception ex)
//        //    {
//        //        return StatusCode(StatusCodes.Status503ServiceUnavailable,
//        //            ex.Message);
//        //    }

//        //}



//    }
//}
