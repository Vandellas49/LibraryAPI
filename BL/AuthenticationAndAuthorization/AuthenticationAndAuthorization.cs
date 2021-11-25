
using System;

namespace BL
{
    public class AuthenticationAndAuthorization
    {
        public string token { get; set; }
        public DateTime expiration { get; set; }
    }
    public class UserDTO
    {
        public string UserName { get; set; }
        public string Password { get; set; }
    }
}
