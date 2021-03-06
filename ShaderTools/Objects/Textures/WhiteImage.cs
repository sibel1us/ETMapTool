﻿using ShaderTools.Utilities.Attributes;
using ShaderTools.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.Textures
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
