using ShaderTools.Shaders.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General.Editor
{
    [ClassDisplay(Name = "Transparency", Description = "Transparency of this surface in level editor. Use 1.0 for opaque textures.")]
    public class Transparency : IEditorDirective
    {
        [Range(minimum: 0.0, maximum: 1.0, ErrorMessage = "Only values between 0 and 1 (inclusive) are supported.")]
        public double Value { get; set; } = double.MinValue;
    }
}
