//using BookingAPP.Data;
//using BookingAPP.Models;
//using Microsoft.AspNetCore.Mvc;

//namespace BookingAPP.Controllers
//{
//    [ApiController]
//    [Route("api/v1/[controller]")]
//    public class GostRezervacijaController : Controller
//    {
//        private readonly BookingContext _Context;
//        public GostRezervacijaController(BookingContext context)
//        {
//            _Context = context;
//        }
//        [HttpGet]
//        public IActionResult Get()
//        {
//            if (!ModelState.IsValid)
//            {
//                return BadRequest(ModelState);
//            }
//            return new JsonResult(_Context.rezervacija);
//        }

//        [HttpPost]
//        public IActionResult Post(GostRezervacija c)
//        {
//            if (c == null)
//            {
//                return NoContent();
//            }
//            _Context.Add(c);
//            _Context.SaveChanges();

//            return StatusCode(StatusCodes.Status201Created, c);
//        }

        
      
//    }
//}