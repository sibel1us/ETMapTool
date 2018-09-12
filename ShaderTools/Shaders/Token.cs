using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders
{
    public class Token
    {
        public const string commentPrefix = "//";
        public const string deformVertexes = "deformVertexes";
        public const string OpeningBrace = "{";
        public const string ClosingBrace = "}";
        public const string surfaceparm = "surfaceparm";

        public const string q3map = "q3map_";
        public const string cull = "cull";
        public const string skyparms = "skyparms";
        public const string fogparms = "fogparms";

        // qer
        public const string qer = "qer_";
        public const string qer_editorimage = "qer_editorimage";
        public const string qer_nocarve = "qer_nocarve";
        public const string qer_trans = "qer_trans";
    }
}
