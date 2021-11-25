namespace Entities.Dtos
{
    public class PersonUpdateDto
    {
        public int? Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public static implicit operator Persons(PersonUpdateDto person)
        {
            return new Persons
            {
                Address = person.Address,
                Email = person.Email,
                Id = person.Id.Value,
                Name = person.Name,
                PhoneNumber = person.PhoneNumber,
                Surname = person.Surname,
            };
        }
    }
}
