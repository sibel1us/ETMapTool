using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.CompilerDirectives
{
    [Format(Token.q3map_vertexscale, "scale")]
    public class VertexScale : ICompilerDirective
    {
        public double Multiplier { get; set; }
    }
}
