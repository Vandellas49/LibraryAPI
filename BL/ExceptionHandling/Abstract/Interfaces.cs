using System;
using System.Collections.Generic;
using System.Text;

namespace BL
{
    public interface ILoggerI
    {
        void Log(Exception ex, Type T);
    }
}
