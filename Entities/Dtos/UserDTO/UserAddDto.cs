using System.Text;

namespace Entities.Dtos
{
    public class UserAddDto
    {
        public string UserName { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public static implicit operator User(UserAddDto model)
        {
            return new User
            {
                Email = model.Email,
                Id = 0,
                Name = model.Name,
                Password = Encoding.ASCII.GetBytes(model.Password),
                Surname = model.Surname,
                UserName = model.UserName
            };
        }
    }
}
