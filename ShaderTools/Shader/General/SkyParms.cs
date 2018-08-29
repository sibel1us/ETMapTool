using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader.General
{
    public class SkyParms
    {
        public ITexture Farbox { get; set; }
        public int CloudHeight { get; set; } = 128;
        public ITexture Nearbox { get; set; } //TODO: deprecated?
    }
}
