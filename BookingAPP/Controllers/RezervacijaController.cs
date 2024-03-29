﻿using BookingAPP.Data;
using BookingAPP.Models;
using Microsoft.AspNetCore.Mvc;

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

        [HttpPost]
        public IActionResult Post(Rezervacija c)
        {
            if (c == null)
            {
                return NoContent();
            }
            _Context.Add(c);
            _Context.SaveChanges();

            return StatusCode(StatusCodes.Status201Created, c);
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