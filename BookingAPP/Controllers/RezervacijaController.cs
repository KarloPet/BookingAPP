using BookingAPP.Data;
using BookingAPP.Extensions;
using BookingAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAPP.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class RezervacijaController : Controller
    {
        private readonly BookingContext _Context;
        public RezervacijaController(BookingContext context)
        {
            _Context = context;
        }
        [HttpGet]
        public IActionResult Get()
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return new JsonResult(_Context.rezervacija);
        }



        //[HttpPost]
        //public IActionResult Post(Rezervacija c)
        //{
        //    if (c == null)
        //    {
        //        return NoContent();
        //    }
        //    _Context.Add(c);
        //    _Context.SaveChanges();

        //    return StatusCode(StatusCodes.Status201Created, c);
        //}
        [HttpPost]
        public IActionResult Post([FromBody] RezervacijaDTOInsertUpdate rezervacijaDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var rezervacija = rezervacijaDto.MapRezervacijaInsertUpdateFromDTO(); // Ovdje mapirate DTO na entitet
            _Context.rezervacija.Add(rezervacija);
            _Context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = rezervacija.Id }, rezervacija.MapRezervacijaReadToDTO()); // Vraćate DTO
        }



        [HttpPut]
        public IActionResult Put(Rezervacija c)
        {
            if (c == null)
            {
                return BadRequest();
            }
            if (c.Id == 0)
            {
                return BadRequest();
            }
            _Context.Update(c);
            _Context.SaveChanges();

            return new JsonResult(c);
        }
        [HttpDelete]
        [Route("{id:int}")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            _Context.Remove(new Rezervacija() { Id = id });
            _Context.SaveChanges();
            return new JsonResult("{poruka: \"Uspiješno obrisano\"}");
        }
    }
}