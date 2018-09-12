using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.Stages
{
    /// <summary>
    /// An explicit texture file, may or may not have file extension
    /// </summary>
    public class Texture : ITexture
    {
        public Image Path { get; set; }
    }
}
