using BookingAPP.Data;
using BookingAPP.Extensions;
using BookingAPP.Models;
using Microsoft.AspNetCore.Mvc;

namespace BookingAPP.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class GostController : Controller
    {
        private readonly BookingContext _Context;
        public GostController(BookingContext context)
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
            return new JsonResult(_Context.gost);
        }
        //[HttpPost]
        //public IActionResult Post(Gost c)
        //{
        //    if (c == null)
        //    {
        //        return NoContent();
        //    }
        //    _Context.Add(c);
        //    Console.WriteLine(c);
        //    _Context.SaveChanges();


        //    return StatusCode(StatusCodes.Status201Created, c);
        //}
        [HttpPost]
        public IActionResult Post([FromBody] GostDTOInsertUpdate gostDto)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var gost = gostDto.MapGostInsertUpdateFromDTO(); // Ovdje mapirate DTO na entitet
            _Context.gost.Add(gost);
            _Context.SaveChanges();

            return CreatedAtAction(nameof(Get), new { id = gost.Id }, gost.MapGostReadToDTO()); // Vraćate DTO
        }


        [HttpPut]
        public IActionResult Put(Gost c)
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
            _Context.Remove(new Gost() { Id = id });
            _Context.SaveChanges();
            return new JsonResult("{poruka: \"Uspiješno obrisano\"}");
        }
    }
}