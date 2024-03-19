//using AutoMapper;
//using Microsoft.AspNetCore.Mvc;
//using BookingAPP.Models;
//using BookingAPP.Extensions;
//using System.Collections.Generic;
//using System.Linq;
//using Microsoft.EntityFrameworkCore;
//using BookingAPP.Data; // Pretpostavlja se da postoji kontekst baze podataka
//using System;

//namespace BookingAPP.Controllers
//{
//    [Route("api/[controller]")]
//    [ApiController]
//    public class GostRezervacijaController : ControllerBase
//    {
//        private readonly BookingContext _context; // Pretpostavka o imenu konteksta baze podataka
//        private readonly IMapper _mapper;

//        public GostRezervacijaController(BookingContext context, IMapper mapper)
//        {
//            _context = context;
//            _mapper = mapper;
//        }

//        // GET: api/GostRezervacija
//        [HttpGet]
//        public ActionResult<IEnumerable<GostRezervacijaDTORead>> GetRezervacije()
//        {
//            var rezervacije = _context.Rezervacije.Include(r => r.GostRezervacije)
//                                                  .ThenInclude(gr => gr.Gost)
//                                                  .ToList();

//            var rezervacijeDto = new List<GostRezervacijaDTORead>();

//            foreach (var rez in rezervacije)
//            {
//                foreach (var gr in rez.GostRezervacije)
//                {
//                    // Pretpostavljam da postoji način da se dođe do ID-a gosta, ovdje je prikazano pojednostavljeno
//                    rezervacijeDto.Add(new GostRezervacijaDTORead(rez.Id, gr.Gost.Id, rez.Id)); // Pretpostavlja se da Gost model ima svojstvo Id
//                }
//            }

//            return Ok(rezervacijeDto);
//        }
//    }
//}
