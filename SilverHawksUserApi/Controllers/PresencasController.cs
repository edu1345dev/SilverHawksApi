using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using SilverHawksUserApi.Data;
using SilverHawksUserApi.Models;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace SilverHawksUserApi.Controllers
{
    [Route("api/[controller]")]
    public class PresencasController : Controller
    {

        private SilverHawksContext _context;
        public PresencasController(SilverHawksContext context)
        {
            _context = context;
        }
        // GET: api/values

        [HttpGet]
        public IEnumerable<Presenca> Get()
        {
            return _context.Presencas.ToList();
        }

        //public void Post([FromBody]string value)
        //{
        //}


        //public void Put(int id, [FromBody]string value)
        //{
        //}


        //public void Delete(int id)
        //{
        //}
    }
}
