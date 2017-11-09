using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using SilverHawksUserApi.Data;
using SilverHawksUserApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SilverHawksUserApi.Controllers
{
  
    [Route("api/[controller]")]
    public class ChamadasController : Controller
    {

        private SilverHawksContext context;
        public ChamadasController(SilverHawksContext _context){
            context = _context;
        }



        // GET: api/values
        [HttpGet]
        public IEnumerable<Chamada> Get()
        {
            return context.Chamadas.ToList();
        }

        // GET: api/values
        [HttpGet("{id}")]
        public IActionResult Get(long id)
        {
            var chamada = context.Chamadas
                                 .Include(p => p.Presencas)
                                 .AsNoTracking()
                                 .SingleOrDefault(c => c.ID == id);

            if(chamada == null){
                return NotFound();
            }


            return new ObjectResult(chamada);
        }

        [HttpPost]
        public IActionResult Create([FromBody] List<Presenca> presencas)
            {
            if (presencas == null)
                {
                    return BadRequest();
                }

            context.Chamadas.Add(new Chamada{Data = presencas.First().Data});
            context.SaveChanges();

            foreach(Presenca p in presencas){
                p.ChamadaID = context.Chamadas.Last().ID;
                context.Presencas.Add(p);
                context.SaveChanges();
            }

            context.SaveChanges();

            return NoContent();
            }

        [HttpPut]
        public void Put(int id, [FromBody]string value)
        {
        }

        [HttpDelete]
        public void Delete(int id)
        {
        }
    }
}
