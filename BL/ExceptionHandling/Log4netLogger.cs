using log4net;
using System;
using System.Collections.Generic;
namespace BL
{
    public class Log4netLogger : ILoggerI
    {
        private static ILog Logg { get; set; }
        public void Log(Exception ex, Type T)
        {
            ILog log = log4net.LogManager.GetLogger(T);
            log.Error(ex);
        }
    }
}
