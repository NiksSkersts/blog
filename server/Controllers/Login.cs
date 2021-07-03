using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using server.Models;

namespace server.Controllers
{
    [Route("API/Login")]
    [ApiController]
    public class Login : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly mainContext main;
        public Login(mainContext main,IConfiguration _configuration)
        {
            this.main = main;
            this._configuration = _configuration;

        }

        [AllowAnonymous]
        [HttpPost]
        public IActionResult DoLogin([FromBody] UserLoginDatum model)
        {
            IActionResult response = Unauthorized();    
            var user = AuthenticateUser(model);
    
            if (user != null)    
            {    
               var tokenString = GenerateJsonWebToken(user);    
                response = Ok(new { token = tokenString });    
           }    
    
            return response;   
        }
        private UserLoginDatum AuthenticateUser(UserLoginDatum login)    
        {    
            var user = main.UserLoginData.Where(p => p.Username.Equals(login.Username)).Single(p => p.Password.Equals(login.Password));
            return user;    
        } 


        public OkObjectResult GenerateJsonWebToken(UserLoginDatum user)
        {
           var authClaims = new List<Claim> {
                  new(ClaimTypes.Name, user.IdUser.ToString()),
                 new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };
           var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));
          var token = new JwtSecurityToken(
                    _configuration["JWT:ValidIssuer"],
                   _configuration["JWT:ValidAudience"],
                    expires: DateTime.Now.AddHours(3),
                   claims: authClaims,
                  signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
               );
               return Ok(new {
                  token = new JwtSecurityTokenHandler().WriteToken(token),
                 expiration = token.ValidTo
               });
            }
    }
}