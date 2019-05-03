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
        private readonly GrepolistoolsContext _context;

        public AlliancesController(GrepolistoolsContext context)
        {
            _context = context;
        }

        // GET: api/Alliances
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Alliance>>> GetAlliances()
        {
            return await _context.Alliances.ToListAsync();
        }

        // GET: api/Alliances/5
        [HttpGet("{id}/{world}/{server}")]
        public async Task<ActionResult<Alliance>> GetAlliance(int id, int world, String server)
        {
            var alliance = await _context.Alliances.FindAsync(id, world, server);

            if (alliance == null)
            {
                return NotFound();
            }

            return alliance;
        }

    }
}
