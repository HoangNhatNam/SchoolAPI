using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolAPI.Exceptions
{
    public class SchoolException: Exception
    {
        public SchoolException()
        {

        }

        public SchoolException(string message): base(message)
        {

        }

        public SchoolException(string message, Exception inner): base(message, inner)
        {

        }
    }
}
