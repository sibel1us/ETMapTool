using ShaderTools.Shaders.Stages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General
{
    public class SkyParms : IGeneralDirective
    {
        public Image Farbox { get; set; }
        public int CloudHeight { get; set; } = 128;
        public Image Nearbox { get; set; } //TODO: deprecated?
    }
}
