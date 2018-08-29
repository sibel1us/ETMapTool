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
        public Dictionary<Surfaceparms, bool> Surfparms { get; set; }
        public DeformVertexes DeformVertexes { get; set; }

        public Shader()
        {
            // Initialize qer_ -editor directives
            Editor = new EditorDirectives();

            // Initialize general directives
            General = new GeneralDirectives();

            // Fill surfaceparms dictionary
            Surfparms = new Dictionary<Surfaceparms, bool>();
            foreach (var enumVal in SurfaceparmHelper.Members)
            {
                Surfparms.Add(enumVal, false);
            }
        }
    }
}
