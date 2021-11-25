﻿namespace BL.Specifications
{
    public class UsersSearchPaginationParams
    {
        private const int MaxPageSize = 50;
        public int PageIndex { get; set; } = 1;

        private int _pageSize = 6;
        public int PageSize
        {
            get => _pageSize;
            set => _pageSize = (value > MaxPageSize) ? MaxPageSize : value;
        }

        public string Sort { get; set; }
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
        private string _username;
        public string Username
        {
            get => _username;
            set => _username = value.ToLower();
        }
        private string _email;
        public string Email
        {
            get => _email;
            set => _email = value.ToLower();
        }
    }
}
