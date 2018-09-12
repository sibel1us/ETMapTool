using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders
{
    /// <summary>
    /// Provides constant string expressions for writer and parser
    /// </summary>
    public static class Token
    {
        static Token()
        {
        }

        #region General Shader Elements
        public const string commentPrefix = "//";
        public const string OpeningBrace = "{";
        public const string ClosingBrace = "}";
        #endregion General Shader Elements

        #region General Directives
        /// <summary>
        /// Used for parsing exclusively.
        /// </summary>
        public const string qer = "qer_";
        public const string qer_editorimage = "qer_editorImage";
        public const string qer_nocarve = "qer_noCarve";
        public const string qer_trans = "qer_trans";

        /// <summary>
        /// Prefix, used for parsing exclusively.
        /// </summary>
        public const string q3map = "q3map_";

        public const string surfaceparm = "surfaceparm";
        public const string deformVertexes = "deformVertexes";
        public const string cull = "cull";
        public const string distancecull = "distancecull";
        public const string skyparms = "skyparms";
        public const string fogparms = "fogparms";

        /// <summary>implicitMap is recognized by ET any "implicit_" except "Mask" and "Blend". Case sensitive.</summary>
        public const string @implicit = "implicit";
        /// <summary>Case sensitive.</summary>
        public const string implicitMap = "implicitMap";
        /// <summary>Case sensitive.</summary>
        public const string implicitMask = "implicitMask";
        /// <summary>Case sensitive.</summary>
        public const string implicitBlend = "implicitBlend";
        #endregion General Directives

        #region Stage Directives
        #endregion Stage Directives

        #region Miscellaneous
        #endregion Miscellaneous
    }
}
