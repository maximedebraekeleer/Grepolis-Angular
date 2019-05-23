using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrepolistoolsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrepolistoolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ConquersController : ControllerBase
    {
        private readonly IConquerRepository _context;

        public ConquersController(IConquerRepository context)
        {
            this._context = context;
        }

        [HttpGet("player/{id}/{server}/{world}")]
        public IEnumerable<Conquer> GetFromPlayer(int id, String server, int world)
        {
            return _context.GetFromPlayer(id, server, world);
        }

        [HttpGet("alliance/{id}/{server}/{world}")]
        public IEnumerable<Conquer> GetFromAlliance(int id, String server, int world)
        {
            return _context.GetFromAlliance(id, server, world);
        }

        [HttpGet("town/{id}/{server}/{world}")]
        public IEnumerable<Conquer> GetFromTown(int id, String server, int world)
        {
            return _context.GetFromTown(id, server, world);
        }

        [HttpGet("player/count/{id}/{server}/{world}")]
        public int[] GetFromPlayerCount(int id, String server, int world)
        {
            return _context.GetConquersAndLossesFromPlayer(id, server, world);
        }
    }
}