using ShaderTools.Utilities;
using ShaderTools.Utilities.IO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.Textures
{
    /// <summary>
    /// An explicit texture file, may or may not have file extension
    /// </summary>
    public class Texture : ITexture
    {
        public string Path { get; set; }
        public TextureStatus Status => FileUtil.Validate(this.Path);

        /// <summary>
        /// Initialize a new Texture and validate it.
        /// </summary>
        /// <param name="path"></param>
        public Texture(string path)
        {

            this.Path = path;
        }
    }
}
