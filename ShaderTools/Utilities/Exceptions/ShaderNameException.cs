using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Utilities.Exceptions
{
    public class ShaderNameException : Exception
    {
        public ShaderNameException(string message) : base(message)
        {
        }
    }
}
