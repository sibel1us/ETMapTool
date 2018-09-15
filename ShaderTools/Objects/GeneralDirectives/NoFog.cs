using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.GeneralDirectives
{
    [Format(Token.nofog)]
    [ClassDisplay(Name = "No Fog", Description = "")]
    public class NoFog : IGeneralDirective
    {
    }
}
