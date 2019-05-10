using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrepolistoolsAPI.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace GrepolistoolsAPI.Data.Repositories
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class PlayersController : ControllerBase
    {
        private readonly IPlayerRepository _context;

        public PlayersController(IPlayerRepository context)
        {
            _context = context;
        }

        // GET: api/Players
        [HttpGet("{server}/{world}")]
        public IEnumerable<Player> GetPlayers(String server, int world)
        {
            return _context.GetAll(server, world);
        }

        // GET: api/Players/5
        [HttpGet("{id}/{server}/{world}")]
        public IEnumerable<Player> GetPlayer(int id, String server, int world)
        {
            return _context.GetById(id, server, world);
        }

        [HttpGet("{id}/{server}/{world}/{date}")]
        public Player GetPlayerDate(int id, String server, int world, String date)
        {
            return _context.GetByIdDate(id, server, world, date);
        }

        [HttpGet("top/{top}/{server}/{world}")]
        public IEnumerable<Player> GetTop(int top, String server, int world)
        {
            return _context.GetTop(top, server, world);
        }
    }
}