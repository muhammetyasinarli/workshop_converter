using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API.Model.Exceptions
{
    public class SystemException : Exception
    {
        public SystemException(string message)
            :base(message)
        {

        }
    }
}
