using ShaderTools.Shaders.Attributes;
using ShaderTools.Shaders.Stages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General
{
    [ClassDisplay(Name = "Skybox Parameters", Description = "")]
    [Format(Token.skyparms, "cloud height", "outerbox", "innerbox")]
    public class SkyParms : IGeneralDirective
    {
        public Textures.Texture Farbox { get; set; }
        public int CloudHeight { get; set; } = 128;
        public Textures.Texture Nearbox { get; set; } //TODO: deprecated?
    }
}
