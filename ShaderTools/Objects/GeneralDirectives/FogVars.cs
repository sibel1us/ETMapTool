using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.GeneralDirectives
{
    [Format(Argument = Token.fogvars)]
    [ClassDisplay(Name = "Fog Vars", Description ="")]
    public class FogVars : IGeneralDirective
    {// TODO: fogvars params
    }
}
