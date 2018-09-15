using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.Exceptions
{
    public class ShaderNameException : Exception
    {
        public ShaderNameException(string message) : base(message)
        {
        }
    }
}
