using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API.Model.Exceptions
{
    public class RequiredFieldException : ValidationException
    {
        public RequiredFieldException(string fieldName)
            :base($"{fieldName} is required")
        {

        }
    }
}
