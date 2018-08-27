using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace ShaderTools.Shader
{
    public class EditorDirectives
    {
        [Display(Name = "Editor Image", Description = "Texture shown for this surface in level editor. Empty values default to the shader name.")]
        public Texture EditorImage { get; set; } = null;

        [Display(Name = "Transparency", Description = "Transparency of this surface in level editor. Use 1.0 for opaque textures.")]
        [Range(minimum: 0.0, maximum: 1.0, ErrorMessage = "Only values between 0 and 1 (inclusive) are supported.")]
        public double Transparency { get; set; } = 1.0;

        [Display(Name = "No Carve", Description = "Brush won't be affected by CSG subtract, useful for water and fog.")]
        public bool NoCarve { get; set; } = false;
    }
}
