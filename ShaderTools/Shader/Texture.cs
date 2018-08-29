using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader
{
    /// <summary>
    /// Provides an interface for implicit and explicit textures.
    /// </summary>
    public interface ITexture
    {
        string Path { get; set; }
        string ToString(bool includeFiletype);
    }

    /// <summary>
    /// An implicit texture, will always result in "-"
    /// </summary>
    public class ImplicitTexture : ITexture
    {
        public string Path { get; set; }
        public string ToString(bool includeFiletype)
        {
            return "-";
        }
    }

    /// <summary>
    /// An explicit texture, may or may not have file extension
    /// </summary>
    public class Texture : ITexture
    {
        public string Path { get; set; }
        public bool FileFound { get; set; }
        public string PathWithExtension { get; set; }
        public string PathWithoutExtension { get; set; }

        public Texture()
        {

        }

        public string ToString(bool includeFiletype)
        {
            return "";
        }
    }
}
