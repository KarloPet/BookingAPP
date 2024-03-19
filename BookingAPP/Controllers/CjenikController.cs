using BookingAPP.Data;
using BookingAPP.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookingAPP.Controllers
{
    [ApiController]
    [Route("api/v1/[controller]")]
    public class CjenikController : Controller
    {
        private readonly BookingContext _Context;
        public CjenikController(BookingContext context)
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
            return new JsonResult(_Context.cjenik);
        }

        [HttpGet("ByMonth")]
        public IActionResult GetByMonth(int year, int month)
        {
            try
            {
                var cjenikByMonth = _Context.cjenik
                    .Where(c => c.Datum.Year == year && c.Datum.Month == month)
                    .ToList();

                return Ok(cjenikByMonth);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, ex.Message);
            }
        }
        [HttpGet("ProvjeriDatum")]
        public async Task<IActionResult> ProvjeriDatum([FromQuery] DateTime datum)
        {
            bool datumPostoji = await _Context.cjenik.AnyAsync(c => c.Datum.Date == datum.Date);
            return Ok(new { exists = datumPostoji });
        }


        [HttpPost]
        public async Task<IActionResult> Post([FromBody] Cjenik cjenik)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            bool datumPostoji = await _Context.cjenik.AnyAsync(c => c.Datum.Date == cjenik.Datum.Date);
            if (datumPostoji)
            {
                return BadRequest("Cijena za odabrani datum već postoji.");
            }

            _Context.cjenik.Add(cjenik);
            await _Context.SaveChangesAsync();

            return CreatedAtAction(nameof(Get), new { id = cjenik.Id }, cjenik);
        }


        [HttpPut]
        [Route("{id:int}")]
        public IActionResult Put(int id, Cjenik cjenik)
        {
            if (id <= 0 || !ModelState.IsValid || cjenik == null)
            {
                return BadRequest();
            }
            try
            {


                var smjerIzBaze = _Context.cjenik.Find(id);

                if (smjerIzBaze == null)
                {
                    return StatusCode(StatusCodes.Status204NoContent, id);
                }

                smjerIzBaze.Cijena = cjenik.Cijena;
                smjerIzBaze.Datum = cjenik.Datum;

                _Context.cjenik.Update(smjerIzBaze);
                _Context.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, smjerIzBaze);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status503ServiceUnavailable,
                    ex.Message);
            }

        }
        [HttpDelete]
        [Route("{id:int}")]
        [Produces("application/json")]
        public IActionResult Delete(int id)
        {
            if (id == 0)
            {
                return BadRequest();
            }
            _Context.Remove(new Cjenik() { Id = id });
            _Context.SaveChanges();
            return new JsonResult(new { poruka = "Obrisano" });
        }
    }
}