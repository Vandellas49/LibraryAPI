namespace BL.Specifications
{
    public class PersonsSearchParams
    {
        private string _name;
        public string Name
        {
            get => _name;
            set => _name = value.ToLower();
        }
        private string _surname;
        public string SurName
        {
            get => _surname;
            set => _surname = value.ToLower();
        }
        private string _phoneNumber;
        public string PhoneNumber
        {
            get => _phoneNumber;
            set => _phoneNumber = value.ToLower();
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => _email = value.ToLower();
        }
    }
}
