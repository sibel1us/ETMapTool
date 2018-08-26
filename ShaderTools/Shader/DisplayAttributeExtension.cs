using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader
{
    /// <summary>
    /// Extra attributes for surfaceparms.
    /// </summary>
    public class SurfaceparmAttribute : Attribute
    {
        public string Name { get; set; }
        public string Description { get; set; } = null;
        public bool Volume { get; set; } = false;
        public bool ETJump { get; set; } = true;
        public bool Unused { get; set; } = false;
        public bool Footsteps { get; set; } = true;
    }
}
