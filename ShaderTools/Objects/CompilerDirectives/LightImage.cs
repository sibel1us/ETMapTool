using ShaderTools.Objects.Textures;
using ShaderTools.Utilities.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.CompilerDirectives
{
    // TODO: warning about editorimage being used if surflight is used
    [ClassDisplay(
        Name = "Light Image",
        Description = "Image used to calculate bounce- and surfacelight. If absent, editor image is used.")]
    public class LightImage : ICompilerDirective
    {
        public Texture Image { get; set; }
    }
}
