using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrepolistoolsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrepolistoolsAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class TownsController : ControllerBase
    {

        private readonly ITownRepository _context;

        public TownsController(ITownRepository context)
        {
            _context = context;
        }

        // GET: api/Towns
        [HttpGet("{server}/{world}")]
        public IEnumerable<Town> GetAll(String server, int world)
        {
            return _context.GetAll(server, world);
        }

        // GET: api/Towns/5
        [HttpGet("{id}/{server}/{world}")]
        public IEnumerable<Town> GetById(int id, String server, int world)
        {
            return _context.GetById(id, server, world);
        }

        [HttpGet("{id}/{server}/{world}/{date}")]
        public Town GetByIdDate(int id, String server, int world, String date)
        {
            return _context.GetByIdDate(id, server, world, date);
        }

        [HttpGet("player/{id}/{server}/{world}")]
        public IEnumerable<Town> GetFromPlayer(int id, String server, int world)
        {
            return _context.GetFromPlayer(id, server, world);
        }

        [HttpGet("count/{server}/{world}")]
        public int countServerWorld(String server, int world)
        {
            return _context.TownCount(server, world);
        }

        [HttpGet("count/{server}")]
        public int countServer(String server)
        {
            return _context.TownCount(server);
        }
    }
}
