using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BL
{
    public class ExceptionManager
    {
        public string GetMessage(Exception exception)
        {

            if (exception is DatabaseOperationException)
            {
                return GetDatabaseExceptionMessage((DatabaseOperationException)exception);
            }

            else if (exception is BusinessOperationException)
            {
                return GetBusinessOperationExceptionMessage((BusinessOperationException)exception);
            }
            else if (exception is ValidationException)
            {
                return GetValidationExceptionMessage((ValidationException)exception);
            }
            return exception.Message;
        }

        private string GetDatabaseExceptionMessage(DatabaseOperationException exception)
        {
            StringBuilder sb = new StringBuilder();
            if (!string.IsNullOrEmpty(exception.DbName))
            {
                sb.Append("DbName=" + exception.DbName);
                sb.Append("-");
            }
            if (!string.IsNullOrEmpty(exception.TableName))
            {
                sb.Append("TableName=" + exception.TableName);
                sb.Append("-");
            }
            if (!string.IsNullOrEmpty(exception.SQLQuery))
            {
                sb.Append("SQLQuery=" + exception.SQLQuery);
            }
            sb.Append("Hata=" + exception.Message);
            return sb.ToString();

        }
        private string GetBusinessOperationExceptionMessage(BusinessOperationException exception)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Namespace=" + exception.NamespaceName);
            sb.Append("-");
            sb.Append("Class=" + exception.ClassName);
            sb.Append("-");
            sb.Append("Method=" + exception.MethodName);
            return sb.ToString();
        }

        private string GetValidationExceptionMessage(ValidationException exception)
        {
            StringBuilder sb = new StringBuilder();
            sb.Append("Mesaj = " + exception.Message);
            sb.Append("------------------------");
            sb.Append("Doğrulama Mesajları");
            foreach (var exceptionValidationMessage in exception.ValidationMessages)
            {
                sb.Append("-- " + exceptionValidationMessage);
            }

            return sb.ToString();
        }

    }
}
