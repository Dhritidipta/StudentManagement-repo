using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using StudentManagement.API.Interfaces;
using StudentManagement.API.Models;

namespace PhyndDemo_v2.Controllers
{

    [Route("authenticate")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private IConfiguration _config;
        private readonly IStudentService _studentService;

        public AuthController(IConfiguration config, IStudentService studentService)
        {
            _config = config;
            _studentService = studentService ?? throw new ArgumentNullException(nameof(studentService));
        }
        [HttpPost]
        [AllowAnonymous]
        public IActionResult Login([FromBody]CredentialsDto creds)
        {
            if (creds != null && creds.Username != null && creds.Password != null)
            {
                var login = _studentService.LoginUser(creds.Username, creds.Password);
                if (login != null)
                {
                    var claims = new[] {
                        new Claim(JwtRegisteredClaimNames.Iat,DateTime.UtcNow.ToString()),
                        new Claim("Username",login.Username),
                    };

                    var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["Jwt:Secret"]));
                    var signIn = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
                    var token = new JwtSecurityToken(
                        _config["Jwt:Issuer"],
                        _config["Jwt:Audience"],
                        claims,
                        expires: DateTime.Now.AddMinutes(30),
                        signingCredentials: signIn);

                    return Ok(new JwtSecurityTokenHandler().WriteToken(token));
                }
                else
                {
                    return BadRequest("Invalid Credentials");
                }

            }
            else
            {
                return BadRequest("Invalid");
            }
        }
    }
}