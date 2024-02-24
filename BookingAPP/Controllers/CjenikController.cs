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
            if(!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            return new JsonResult(_Context.cjenik);
        }

        [HttpPost]
        public IActionResult Post(Cjenik c) 
        {
            if (c == null)
            {
                return NoContent();
            }
            _Context.Add(c);
            _Context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, c);
        }

        //[HttpPut]
        //[Route("{id:int}")]
        //public IActionResult Put(int id, Cjenik c) 
        //{
        //    if (c == null)
        //    {
        //        return BadRequest();
        //    }
        //    if(c.Id == 0)
        //    {
        //        return BadRequest();
        //    }
        //    _Context.Update(c);
        //    _Context.SaveChanges();

        //    return new JsonResult(c);
        //}

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
        public IActionResult Delete(int id) 
        {
           if (id == 0) 
            {
                return BadRequest();
            }
           _Context.Remove(new Cjenik() { Id = id });
           _Context.SaveChanges();
            return new JsonResult("{poruka: \"Uspiješno obrisano\"}");
        }
    }
}
