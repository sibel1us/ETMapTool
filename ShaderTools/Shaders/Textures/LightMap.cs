using ShaderTools.Shaders.Attributes;
using ShaderTools.Shaders.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.Stages
{
    /// <summary>
    /// Is always "$lightmap"
    /// </summary>
    [ClassDisplay(Name = "Lightmap", Description = "Renders the q3map2-compiled lightmap of the surface.")]
    public class LightMap : ITexture
    {   // TODO: warning about no lightmap stage when surfaceparm nolightmap is missing
        // TODO: must be used with rgbGen identity!
        public override string ToString()
        {
            return "$lightmap";
        }
    }
}
