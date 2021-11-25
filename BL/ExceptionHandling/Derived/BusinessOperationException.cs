using System;
namespace BL
{
    public class BusinessOperationException : BaseException
    {
        public string NamespaceName { get; set; }
        public string ClassName { get; set; }
        public string MethodName { get; set; }
        public BusinessOperationException(string message) : base(message)
        {
        }

        public BusinessOperationException(string message, Exception innerException) : base(message, innerException)
        {
        }
    }
}
