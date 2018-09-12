using ShaderTools.Shaders.Stages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General
{
    /// <summary>
    /// An implicit texture, will always result in "-"
    /// </summary>
    public class ImplicitMap : ITexture
    {
        // TODO: what to do with this?
        public Image Image { get; set; }

        public override string ToString()
        {
            return "-";
        }
    }
}
