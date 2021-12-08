using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API.Model.Exceptions
{
    public class DatabaseException : SystemException
    {
        public DatabaseException(string message):base(message)
        {

        }
    }
}
