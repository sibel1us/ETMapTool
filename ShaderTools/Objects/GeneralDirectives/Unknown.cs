using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.GeneralDirectives
{
    /// <summary>
    /// Represents a line in .shader-file that doesn't correspond to any known general directive.
    /// </summary>
    class Unknown : IGeneralDirective
    {
        public string Value { get; set; }

        public Unknown(string line)
        {
            Value = line;
        }
    }
}
