using ShaderTools.Shaders.Helpers;
using ShaderTools.Shaders.Stages;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General
{
    /// <summary>
    /// Interface for qer_editorImage, qer_trans and qer_noCarve
    /// </summary>
    public interface IEditorDirective : IGeneralDirective
    {
    }

    [ClassDisplay(Name = "Editor Image", Description = "Texture shown for this surface in level editor. Empty values default to the shader name.")]
    public class EditorImage : IEditorDirective
    {
        public Image Image { get; set; }
    }

    [ClassDisplay(Name = "Transparency", Description = "Transparency of this surface in level editor. Use 1.0 for opaque textures.")]
    public class EditorTransparency : IEditorDirective
    {
        [Range(minimum: 0.0, maximum: 1.0, ErrorMessage = "Only values between 0 and 1 (inclusive) are supported.")]
        public double Value { get; set; } = double.MinValue;
    }

    [ClassDisplay(Name = "No Carve", Description = "Brush won't be affected by CSG subtract, useful for water and fog.")]
    public class EditorNoCarve : IEditorDirective
    {
    }
}
