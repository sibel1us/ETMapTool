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
        #region File System
        public const string ETexe = "ET.exe";
        public const string etmain = "etmain";
        public const string textures = "textures";
        public const string scripts = "scripts";
        public const string models = "models";
        public const string pak0 = "pak0.pk3";
        #endregion File System


        #region General Shader Elements
        public const string commentPrefix = "//";
        public const string OpeningBrace = "{";
        public const string ClosingBrace = "}";
        #endregion General Shader Elements

        #region General Directives
        /// <summary>:p
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

        public const string polygonOffset = "polygonOffset";
        public const string lightgridAmbientMultiplier = "lightgridmulamb";
        public const string lightgridDirectionalMultiplier = "lightgridmuldir";
        public const string entityMergable = "entityMergable";
        public const string portal = "portal";
        public const string surfaceparm = "surfaceparm";
        public const string deformVertexes = "deformVertexes";
        public const string nofog = "nofog";
        public const string cull = "cull";
        public const string distancecull = "distancecull";
        public const string nocompress = "nocompress";
        public const string allowcompress = "allowcompress";
        public const string skyparms = "skyparms";
        public const string sunshader = "sunshader";
        public const string fogparms = "fogparms";
        public const string fogvars = "fogvars";
        public const string skyfogvars = "skyfogvars";
        public const string waterfogvars = "waterfogvars";

        /// <summary>implicitMap is recognized by ET any "implicit_" except "Mask" and "Blend". Case sensitive.</summary>
        public const string @implicit = "implicit";
        public const string implicitMap = "implicitMap";
        public const string implicitMask = "implicitMask";
        public const string implicitBlend = "implicitBlend";
        #endregion General Directives

        #region Stage Directives
        public const string rgbGen = "rgbGen";
        #endregion Stage Directives

        #region Miscellaneous
        #endregion Miscellaneous
    }
}
