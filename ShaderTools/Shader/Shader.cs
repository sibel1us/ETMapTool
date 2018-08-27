using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ShaderTools.Shader.General;
using ShaderTools.Shader.Surfaceparm;

namespace ShaderTools.Shader
{
    public class Shader
    {
        public EditorDirectives Editor { get; set; }
        public GeneralDirectives General { get; set; }
        public List<Surfaceparms> Surfaceparms { get; set; }
        public DeformVertexes DeformVertexes { get; set; }
    }
}
