using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Utilities.Exceptions
{
    class ShaderFileStructureException : Exception
    {
        public ShaderFileStructureException(string message) : base(message)
        {
        }

        public ShaderFileStructureException(string message, int line, string path) : base($"{message} (line {line} in file: {path})")
        {
        }

        public ShaderFileStructureException(string message, string path) : base($"{message} (file: {path})")
        {
        }
    }
}
