using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ETMapHelper.Exceptions
{
    public class MapStructureException : Exception
    {
        public MapStructureException()
        {
        }

        public MapStructureException(string message) : base(message)
        {
        }

        public MapStructureException(string message, Exception inner) : base(message, inner)
        {
        }
    }
}
