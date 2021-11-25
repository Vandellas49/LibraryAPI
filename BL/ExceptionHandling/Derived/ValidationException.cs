using System;
using System.Collections.Generic;

namespace BL
{
    public class ValidationException : BaseException
    {
        public List<string> ValidationMessages { get; }

        public ValidationException(string message) : base(message)
        {
            ValidationMessages = new List<string>();
        }

        public ValidationException(string message, Exception innerException) : base(message, innerException)
        {
            ValidationMessages = new List<string>();
        }
    }
}
