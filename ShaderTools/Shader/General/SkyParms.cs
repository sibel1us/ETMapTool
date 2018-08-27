using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader.General
{
    public class SkyParms
    {
        public Texture Farbox { get; set; }
        public double CloudHeight { get; set; } = 128;
        public Texture Nearbox { get; set; } //TODO: deprecated?
    }
}
