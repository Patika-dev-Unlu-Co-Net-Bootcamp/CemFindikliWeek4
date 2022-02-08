using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using UnluCo.Week1.Jwt;
using UnluCo.Week1.Models;

namespace UnluCo.Week1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private readonly TokenGenerator _tokenGenerator;

        public LoginController(TokenGenerator tokenGenerator)
        {
            _tokenGenerator = tokenGenerator;
        }
        [HttpPost]
        public Token Login([FromBody] User user)
        {
            throw new Exception("sdjgskgjsd");
            Token token = new Token();
            if (user.Password == "1" && user.Email == "aa@a.com")
            {
                token = _tokenGenerator.CreateToken(user);
            }

            return token;
        }
    }
}
