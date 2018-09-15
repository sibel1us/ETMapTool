using ShaderTools.Utilities.Attributes;
using ShaderTools.Objects.StageDirectives;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.EditorDirectives
{
    [Format(Token.qer_editorimage, "texture")]
    [ClassDisplay(Name = "Editor Image", Description = "Texture shown for this surface in level editor. Empty values default to the shader name.")]
    public class EditorImage : IEditorDirective
    {
        public Textures.Texture Image { get; set; }
    }
}
