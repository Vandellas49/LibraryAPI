using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using BL;
using BL.InterFaces;
using BL.Specifications;
using Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace LibraryAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [AllowAnonymous]
    public class AccountController : ControllerBase
    {

        readonly IConfiguration Configuration;
        readonly IGenericRepository<User> repository;

        public AccountController(IConfiguration _Configuration, IGenericRepository<User> _repository)
        {
            Configuration = _Configuration;
            repository = _repository;
        }
        /// <summary>
        /// Web Servisin Authenticate sağlayan method
        /// </summary>
        [HttpPost]
        public IActionResult Authenticate(UserSearchUserNamePasswordParams model)
        {
            var user = repository.GetByIdAsync(new UsersWithFiltersForAuthenticationSpecification(model)).Result;
            if (user == null || user.UserRole.Count == 0)
                return Unauthorized();
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("AppSettings:Secret"));
            var claims = new ClaimsIdentity(new Claim[] { new Claim(ClaimTypes.NameIdentifier, user.Id.ToString()), new Claim(ClaimTypes.Name, user.Name), new Claim(ClaimTypes.Surname, user.Surname), new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) });
            foreach (var item in user.UserRole) { claims.AddClaim(new Claim(ClaimTypes.Role, item.Role.ToString())); }
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = claims,
                Expires = DateTime.UtcNow.AddHours(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return Ok(new AuthenticationAndAuthorization
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            });
        }
    }
}
