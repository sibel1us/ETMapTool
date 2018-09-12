using ShaderTools.Shaders.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General
{
    [Format(Token.skyfogvars, "color", "distance to opaque")]
    [ClassDisplay(Name = "Sky Fog Vars", Description = "")]
    public class SkyFogVars : IGeneralDirective
    {
    }
}
