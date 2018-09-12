using ShaderTools.Shaders.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.Stages
{
    /// <summary>
    /// Is always "$whiteimage"
    /// </summary>
    [ClassDisplay(Name = "WhiteImage", Description = "Produces a full white image. Useful in conjunction with rgbGen and alphaGen.")]
    public class WhiteImage : ITexture
    {
        public override string ToString()
        {
            return "$whiteimage";
        }
    }
}
