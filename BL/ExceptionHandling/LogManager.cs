using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public class LogManager
    {
        public ILoggerI GetLogger()
        {
            return new Log4netLogger();
        }
    }
}
