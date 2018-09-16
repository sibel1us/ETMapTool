using ShaderTools.Utilities.Attributes;
using ShaderTools.Objects.StageDirectives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaderTools.Objects.Textures;

namespace ShaderTools.Objects.GeneralDirectives
{
    [ClassDisplay(Name = "Skybox Parameters", Description = "")]
    [Format(Token.skyparms, "cloud height", "outerbox", "innerbox")]
    public class SkyParms : IGeneralDirective
    {
        public Texture Farbox { get; set; }
        public int CloudHeight { get; set; } = 128;
        public Texture Nearbox { get; set; } //TODO: deprecated?
    }
}
