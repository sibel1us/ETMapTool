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

    /*
        // This is fixed fog for the skybox/clouds determined solely by the shader
        // it will not change in a level and will not be necessary
        // to force clients to use a sky fog the server says to.
        // skyfogvars <(r,g,b)> <dist>
    */
}
