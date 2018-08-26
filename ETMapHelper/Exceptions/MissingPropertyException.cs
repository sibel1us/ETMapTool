using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMapHelper.Exceptions
{
    class MissingPropertyException : Exception
    {
        public MissingPropertyException()
        {
        }

        public MissingPropertyException(string message) : base(message)
        {
        }

        public MissingPropertyException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
