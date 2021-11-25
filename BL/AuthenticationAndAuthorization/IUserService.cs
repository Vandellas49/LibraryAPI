using BL.InterFaces;
using BL.Specifications;
using Entities;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace BL
{
    public interface IUserService
    {
        AuthenticationAndAuthorization Authenticate(UserSearchUserNamePasswordParams model);
    }
    public class UserService : IUserService
    {

        readonly IConfiguration Configuration;
        private readonly IGenericRepository<User> repository;

        public UserService(IConfiguration _Configuration, IGenericRepository<User> _repository)
        {
            Configuration = _Configuration;
            repository = _repository;
        }

        public AuthenticationAndAuthorization Authenticate(UserSearchUserNamePasswordParams model)
        {
            var user = repository.GetByIdAsync(new UsersWithFiltersForAuthenticationSpecification(model));

            // return null if user not found
            if (user == null)
                return null;

            // authentication successful so generate jwt token
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(Configuration.GetValue<string>("Secret"));
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new Claim[]
                {
                    new Claim(ClaimTypes.Name, user.Id.ToString())
                }),
                Expires = DateTime.UtcNow.AddSeconds(1),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            return new AuthenticationAndAuthorization
            {
                token = new JwtSecurityTokenHandler().WriteToken(token),
                expiration = token.ValidTo
            };
        }
     
    }

}
