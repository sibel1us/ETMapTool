using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.CompilerDirectives
{
    [ClassDisplay(Name = "", Description = "")]
    [Format(Token.q3map_cloneShader, "shadername")]
    public class CloneShader : ICompilerDirective
    {
        public ShaderReference Reference { get; set; }
    }
}
