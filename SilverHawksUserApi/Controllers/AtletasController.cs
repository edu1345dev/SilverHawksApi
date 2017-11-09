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
    public class AtletasController : Controller
    {

        private readonly SilverHawksContext context;

        public AtletasController(SilverHawksContext _context)
        {
            context = _context;
        }

        [HttpGet]
        public async Task<IActionResult> Get(int mes)
        {
            var atletas = context.Atletas.ToList();
            var atletas1 = new List<Atleta>();

            foreach (Atleta a in atletas)
            {
                if (mes == 0)
                {
                    atletas1.Add(await context.Atletas
                            .Include(s => s.Presencas)
                            .AsNoTracking()
                                 .SingleOrDefaultAsync(m => m.ID == a.ID));
                }
                else
                {

                    var atleta = await context.Atletas
                        .SingleOrDefaultAsync(m => m.ID == a.ID);

                    var presenca = context.Entry(atleta)
                                           .Collection(p => p.Presencas)
                                           .Query()
                                           .Where(p => p.Data.Month == mes)
                                           .ToList();
                    atleta.Presencas = presenca;
                    atletas1.Add(atleta);
                }
            }

            return new ObjectResult(atletas1);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> Get(long id, int mes)
        {

            var atleta = new Atleta();


            if (mes == 0)
            {

                atleta = await context.Atletas
                                           .Include(s => s.Presencas)
                                           .AsNoTracking()
                                           .SingleOrDefaultAsync(m => m.ID == id);

            }
            else
            {

                atleta = await context.Atletas
                    .SingleOrDefaultAsync(m => m.ID == id);

                var presenca = context.Entry(atleta)
                                       .Collection(p => p.Presencas)
                                       .Query()
                                       .Where(p => p.Data.Month == mes)
                                       .ToList();
                atleta.Presencas = presenca;

            }

            if (atleta == null)
            {
                return NotFound();
            }

            return new ObjectResult(atleta);
        }

        // POST api/values
        [HttpPost]
        public IActionResult Create([FromBody]Atleta atleta)
        {
            if(atleta == null){
                return BadRequest();
            }

            var atleta2 = context.Atletas.FirstOrDefault(n => n.Numero == atleta.Numero);

            if (atleta2 != null && atleta.Numero.Equals(atleta2.Numero))
                {
                return new ObjectResult(new Error { Message = "Numero já existente" });
                //return new BadRequestObjectResult(new Error { Message = "Numero já existente" });
                }

            context.Atletas.Add(atleta);
            context.SaveChanges();

            return new CreatedResult("database",atleta);
        }

        // PUT api/values/5

        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5

        public void Delete(int id)
        {
        }
    }
}
