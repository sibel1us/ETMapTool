using ShaderTools.Shaders.Stages;
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
        Image Texture { get; set; }
    }

    /// <summary>
    ///
    /// </summary>
    public class ImplicitMap : IImplicitMap
    {
        // TODO: what to do with this?
        /// <summary>
        /// Texture to be mapped implicitly. If <see langword="null"/>, will try to use the shader name.
        /// </summary>
        public Image Texture { get; set; }

        public override string ToString()
        {
            return "-";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ImplicitBlend : IImplicitMap
    {
        /// <summary>
        /// Texture to be mapped implicitly. If <see langword="null"/>, will try to use the shader name.
        /// </summary>
        public Image Texture { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class ImplicitMask : IImplicitMap
    {
        /// <summary>
        /// Texture to be mapped implicitly. If <see langword="null"/>, will try to use the shader name.
        /// </summary>
        public Image Texture { get; set; }
    }
}
