using ShaderTools.Shaders.Attributes;
using ShaderTools.Shaders.Helpers;
using ShaderTools.Shaders.Stages;
using ShaderTools.Shaders.Textures;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.General
{
    /// <summary>
    /// Interface for <see cref="ImplicitMap"/>, <see cref="ImplicitBlend"/> and <see cref="ImplicitMask"/>.
    /// </summary>
    public interface IImplicitMap : IGeneralDirective
    {
        /// <summary>
        /// Texture to be mapped implicitly. If <see langword="null"/>, will try to use the shader name.
        /// </summary>
        Texture Texture { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    [Format(Token.implicitMap, "texture")]
    public class ImplicitMap : IImplicitMap
    {
        // TODO: what to do with this?
        /// <summary>
        /// Texture to be mapped implicitly. If <see langword="null"/>, will try to use the shader name.
        /// </summary>
        public Texture Texture { get; set; }

        public override string ToString()
        {
            return "-";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    [Format(Token.implicitBlend, "texture")]
    public class ImplicitBlend : IImplicitMap
    {
        /// <summary>
        /// Texture to be mapped implicitly. If <see langword="null"/>, will try to use the shader name.
        /// </summary>
        public Texture Texture { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    [Format(Token.implicitMap, "texture")]
    public class ImplicitMask : IImplicitMap
    {
        /// <summary>
        /// Texture to be mapped implicitly. If <see langword="null"/>, will try to use the shader name.
        /// </summary>
        public Texture Texture { get; set; }
    }
}
