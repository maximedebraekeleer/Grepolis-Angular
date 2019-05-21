using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GrepolistoolsAPI.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using GrepolistoolsAPI.DTOs;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace GrepolistoolsAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AccountController : ControllerBase
    {
        private readonly SignInManager<IdentityUser> _signInManager;
        private readonly UserManager<IdentityUser> _userManager;
        private readonly IUserRepository _userRepository;
        private readonly IConfiguration _config;
        public AccountController(SignInManager<IdentityUser> signInManager, UserManager<IdentityUser> userManager, IUserRepository userRepository, IConfiguration config)
        {
            _signInManager = signInManager;
            _userManager = userManager;
            _userRepository = userRepository;
            _config = config;
        }

        [AllowAnonymous]
        [HttpGet("checkusername")]
        public async Task<ActionResult<Boolean>>
        CheckAvailableUserName(string username)
        {
            var user = await _userManager.FindByNameAsync(username);
            return (user == null);
        }

        [AllowAnonymous]
        [HttpGet("checkemail")]
        public async Task<ActionResult<Boolean>>
        CheckAvailableEmail(string email)
        {
            var user = await _userManager.FindByEmailAsync(email);
            return (user == null);
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<String>> CreateToken(LoginDTO model)
        {
            var user = await _userManager.FindByNameAsync(model.Username);

            if (user != null)
            {
                var result = await _signInManager.CheckPasswordSignInAsync(user, model.Password, false);

                if (result.Succeeded)
                {
                    string token = GetToken(user);
                    return Created("", token); //returns only the token                    
                }
            }
            return BadRequest();
        }

        private String GetToken(IdentityUser user)
        {
            // Create the token
            var claims = new[]
            {
              new Claim(JwtRegisteredClaimNames.Sub, user.Email),
              new Claim(JwtRegisteredClaimNames.UniqueName, user.UserName)
            };

            var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Tokens:Key"]));

            var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

            var token = new JwtSecurityToken(
              null, null,
              claims,
              expires: DateTime.Now.AddMinutes(30),
              signingCredentials: creds);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }


        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult<String>> Register(RegisterDTO model)
        {
            IdentityUser idUser = new IdentityUser { UserName = model.Username, Email = model.Email };
            User user = new User { Email = model.Email, Username = model.Username };
            var result = await _userManager.CreateAsync(idUser, model.Password);

            if (result.Succeeded)
            {
                _userRepository.AddUser(user);
                _userRepository.SaveChanges();
                string token = GetToken(idUser);
                return Created("", token);
            }
            return BadRequest();
        }
    }
}
