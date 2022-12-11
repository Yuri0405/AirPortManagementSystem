using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using AirPortWebAPI.Models;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Collections.Generic;
using System.Linq;
using Microsoft.AspNetCore.Authorization;

namespace AirPortWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly AirportManagementSystemContext _db;
        private readonly IConfiguration _config;

        public UsersController(AirportManagementSystemContext db, IConfiguration config)
        {
            _db = db;
            _config = config;
        }

        [HttpGet]
        public ActionResult Hello()
        {
            return Content("Hello users!;)");
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<ActionResult> RegisterUser(User user)
        {
            var record = await _db.Users.FirstOrDefaultAsync(r => r.UserName == user.UserName);

            if (record == null)
            {
                _db.Users.Add(user);
                _db.Carts.Add(new Cart { UserId = user.Id });
                _db.SaveChanges();
            }
            else
            {
                return BadRequest("User already exist!");
            }

            return Ok(user.UserName);
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public ActionResult LoginUser(User login)
        {
            //var record = await _db.Users.FirstOrDefaultAsync(r => r.UserName == login.UserName);

            
            var tokenString = GenerateJSONWebToken(login);

            if(tokenString == null)
            {
                return Unauthorized("User not exist!");
            }

            return Ok("Your Authentification token:" + tokenString);
        }

        [Authorize]
        [HttpGet("restricted")]
        public ActionResult GetInfo()
        {
            var currentUser = HttpContext.User;
            return Content("Hello, " + currentUser.Identity.Name);
        }

        private string GenerateJSONWebToken(User userInfo)
        {
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Key"]));
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);

            var identity = GetIdentity(userInfo.UserName, userInfo.Password);
            
            if(identity == null)
            {
                return null;
            }
            

            var token = new JwtSecurityToken(_config["Jwt:Issuer"],
                _config["Jwt:Issuer"], identity.Claims,
                expires: DateTime.Now.AddMinutes(1),
                signingCredentials: credentials);
            return new JwtSecurityTokenHandler().WriteToken(token);       
        }

        private ClaimsIdentity GetIdentity(string username,string password)
        {
            User user =  _db.Users.FirstOrDefault(u => u.UserName == username && u.Password == password);

            if(user != null)
            {
                var claims = new List<Claim>
                {
                   new Claim(ClaimsIdentity.DefaultNameClaimType, user.UserName),
                   new Claim("UserID",user.Id.ToString())
                };

                ClaimsIdentity claimsIdentity =
                new ClaimsIdentity(claims, "Token", ClaimsIdentity.DefaultNameClaimType,
                    ClaimsIdentity.DefaultRoleClaimType);
                return claimsIdentity;


            }

            return null;
        }
    }
}
