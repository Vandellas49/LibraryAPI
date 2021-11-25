using System;

namespace BL
{
    public abstract class BaseException:Exception
    {
        protected BaseException(string message) : base(message)
        {

        }

        protected BaseException(string message, Exception innerException) : base(message, innerException)
        {

        }
    }
}
