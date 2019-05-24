using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrepolistoolsAPI.DTOs;
using GrepolistoolsAPI.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace GrepolistoolsAPI.Controllers
{
    [Route("api/[controller]")]
    [Authorize(AuthenticationSchemes = JwtBearerDefaults.AuthenticationScheme)]
    [ApiController]
    public class PlayerTrackerController : ControllerBase
    {
        private readonly IUserRepository _users;
        private readonly IPlayerTrackerRepository _context;

        public PlayerTrackerController(IPlayerTrackerRepository context, IUserRepository users)
        {
            _context = context;
            _users = users;
        }
        [HttpPost]
        public ActionResult<PlayerTracker> PostTracker(PlayerTrackerDTO pt)
        {
            PlayerTracker tracker = new PlayerTracker() { Username = pt.Username, Player_Id = pt.Player_Id, Server_Name = pt.Server_Name, World_Id = pt.World_Id };
            _context.Add(tracker);
            _context.SaveChanges();

            return CreatedAtAction(nameof(GetTracker),
                new { user = tracker.Username, player = tracker.Player_Id, server = tracker.Server_Name, world = tracker.World_Id }, tracker);
        }

        [AllowAnonymous]
        [HttpPost("{user}/{player}/{server}/{world}")]
        public PlayerTracker GetTracker(string user, int player, string server, int world)
        {
            return _context.GetTracker(user, player, server, world);
        }

        [HttpGet]
        public IEnumerable<PlayerTracker> GetFromUser(IdentityUser user)
        {
            return _context.GetFromUser(user.UserName);
        }
    }
}