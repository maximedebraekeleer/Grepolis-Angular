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
    public class AlliancesController : ControllerBase
    {
        private readonly IAllianceRepository _context;

        public AlliancesController(IAllianceRepository context)
        {
            _context = context;
        }

        // GET: api/Alliances
        [HttpGet]
        public IEnumerable<Alliance> GetAlliances(String server, int world)
        {
            return _context.GetAll(server, world);
        }

        // GET: api/Alliances/5
        [HttpGet("{id}/{server}/{world}")]
        public IEnumerable<Alliance> GetAlliance(int id, String server, int world)
        {
            return _context.GetById(id, server, world);
        }

        [HttpGet("{id}/{server}/{world}/{date}")]
        public Alliance GetAlliance(int id, String server, int world, String date)
        {
            return _context.GetByIdDate(id, server, world, date);
        }

        [HttpGet("top/{top}/{server}/{world}")]
        public IEnumerable<Alliance> GetTop(int top, String server, int world)
        {
            return _context.GetTop(top, server, world);
        }

        [HttpGet("count/{server}/{world}")]
        public int CountServerWorld(String server, int world)
        {
            return _context.AllianceCount(server, world);
        }

        [HttpGet("count/{server}")]
        public int CountServerWorld(String server)
        {
            return _context.AllianceCount(server);
        }
    }
}
