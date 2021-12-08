using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading.Tasks;

namespace LinkConverter.API.Model.Exceptions
{
    public static class ExceptionUtil
    {
        public static int GetHttpStatusCode(this System.Exception exception)
        {
            var validationException = exception as ValidationException;
            if (validationException != null)
            {
                return (int)HttpStatusCode.BadRequest;
            }
            return (int)HttpStatusCode.InternalServerError;
        }
    }
}
