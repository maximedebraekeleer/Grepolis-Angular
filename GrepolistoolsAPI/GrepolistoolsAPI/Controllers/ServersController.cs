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
    [Route("api/[controller]")]
    [ApiController]
    public class ServersController : ControllerBase
    {

        private readonly IServerRepository _servers;

        public ServersController(IServerRepository context)
        {
            _servers = context;
        }

        // GET: api/Servers
        [HttpGet]
        public IEnumerable<Server> GetServers()
        {
            return _servers.GetAll();
        }

        // GET: api/Servers/5
        [HttpGet("{name}")]
        public ActionResult<Server> GetServer(string name)
        {
            Server server = _servers.GetServer(name);
            if (server == null) return NotFound();
            return server;
        }

    }
}
