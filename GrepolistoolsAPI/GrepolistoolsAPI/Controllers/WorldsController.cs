using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using GrepolistoolsAPI.Data;
using GrepolistoolsAPI.Models;

namespace GrepolistoolsAPI.Controllers
{
    [ApiConventionType(typeof(DefaultApiConventions))]
    [Produces("application/json")]
    [Route("api/[controller]")]
    [ApiController]
    public class WorldsController : ControllerBase
    {
        private readonly IWorldRepository _worlds;

        public WorldsController(IWorldRepository context)
        {
            _worlds = context;
        }

        // GET: api/Worlds
        [HttpGet]
        public IEnumerable<World> GetWorlds()
        {
            return _worlds.GetAll();
        }

        [HttpGet("{server}")]
        public IEnumerable<World> GetFromServer(String server)
        {
            return _worlds.GetAllFromServer(server).OrderByDescending(w => w.Id);
        }

        // GET: api/Worlds/5
        [HttpGet("{server}/{id}")]
        public ActionResult<World> GetWorld(String server, int id)
        {

            World world = _worlds.GetById(server,id);
            if (world == null) return NotFound();
            return world;

        }

        [HttpGet("count/{server}")]
        public int WorldCount(String server)
        {
            return _worlds.WorldCount(server);
        }
    }
}
