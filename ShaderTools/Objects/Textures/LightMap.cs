using ShaderTools.Utilities.Attributes;
using ShaderTools.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.Textures
{
    /// <summary>
    /// Is always "$lightmap"
    /// </summary>
    [ClassDisplay(Name = "Lightmap", Description = "Renders the q3map2-compiled lightmap of the surface.")]
    public class Lightmap : ITexture
    {   
        // TODO: warning about no lightmap stage when surfaceparm nolightmap is missing
        // TODO: must be used with rgbGen identity!
        public override string ToString()
        {
            return "$lightmap";
        }
    }
}
