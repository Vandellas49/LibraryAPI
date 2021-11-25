using System;

namespace BL
{
    public class DatabaseOperationException : BaseException
    {
        public string DbName { get; set; }
        public string TableName { get; set; }
        public string SQLQuery { get; set; }

        public DatabaseOperationException(string message) : base(message)
        {
        }

        public DatabaseOperationException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
