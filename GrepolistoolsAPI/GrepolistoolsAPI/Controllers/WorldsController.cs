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

        // GET: api/Worlds/5
        [HttpGet("{id}/{server}")]
        public ActionResult<World> GetWorld(int id, String server)
        {

            World world = _worlds.GetById(id, server);
            if (world == null) return NotFound();
            return world;

        }

    }
}
