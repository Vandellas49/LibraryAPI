using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BL
{
    public class ExceptionCatch : IExceptionFilter
    {
        public void OnException(ExceptionContext context)
        {
            var controller = ((Microsoft.AspNetCore.Mvc.Controllers.ControllerActionDescriptor)context.ActionDescriptor);
            var ControllerType = controller.ControllerTypeInfo;
            LogManager manager = new LogManager();
            ILoggerI logger = manager.GetLogger();
            logger.Log(context.Exception, ControllerType);
            ExceptionManager Exmanager = new ExceptionManager();
            context.Result = new BadRequestObjectResult(Exmanager.GetMessage(context.Exception));

        }
    }
}
