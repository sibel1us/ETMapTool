using ShaderTools.Shaders.Attributes;
using ShaderTools.Shaders.Stages;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General.Editor
{
    [Format(Token.qer_editorimage, "texture")]
    [ClassDisplay(Name = "Editor Image", Description = "Texture shown for this surface in level editor. Empty values default to the shader name.")]
    public class EditorImage : IEditorDirective
    {
        public Image Image { get; set; }
    }
}
