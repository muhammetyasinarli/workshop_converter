﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace LinkConverter.API.Model.Exceptions
{
    public class ValidationException : Exception
    {
        public ValidationException(string message) 
            : base(message: message)
        {

        }
    }
}
