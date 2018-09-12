using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General
{
    /// <summary>
    /// Represents a line in .shader-file that doesn't correspond to any known general directive.
    /// </summary>
    class UnknownGeneralDirective : IGeneralDirective
    {
        public string Value { get; set; }

        public UnknownGeneralDirective(string line)
        {
            Value = line;
        }
    }
}
