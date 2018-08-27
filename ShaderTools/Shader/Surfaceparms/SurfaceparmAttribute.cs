using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader.Surfaceparms
{
    /// <summary>
    /// Extra attributes for surfaceparms.
    /// </summary>
    public class SurfaceparmAttribute : Attribute
    {
        public SurfparmFlags Flags { get; set; }
        public Surfaceparms Related { get; set; }
        public Surfaceparms[] UseWith { get; set; }

        public SurfaceparmAttribute() { }

        public SurfaceparmAttribute(SurfparmFlags Flags)
        {
            this.Flags = Flags;
        }
    }

    [Flags]
    public enum SurfparmFlags
    {
        None = 0,
        Volume = 1,
        Footsteps = 2,
        ETJump = 4,
        AffectsLight = 8,
        AffectsVis = 16,
        Unused = 32,
        Avoid = 64,
    }
}
