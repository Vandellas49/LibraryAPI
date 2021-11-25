﻿namespace Entities.Dtos
{
    public class PersonAddDto
    {
        public string Name { get; set; }
        public string Surname { get; set; }
        public string PhoneNumber { get; set; }
        public string Address { get; set; }
        public string Email { get; set; }
        public static implicit operator Persons(PersonAddDto person)
        {
            return new Persons
            {
              Address=person.Address,
              Email=person.Email,
              Id=0,
              Name=person.Name,
              PhoneNumber=person.PhoneNumber,
              Surname=person.Surname,
            };
        }

    }
}
