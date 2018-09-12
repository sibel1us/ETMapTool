using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.Stages
{
    public class Image
    {
        public string Path { get; set; }
        public bool FileFound { get; set; }
        public string PathWithExtension { get; }
        public string PathWithoutExtension { get; }

        public Image(string path)
        {

        }

        /// <summary>
        /// Returns the image's path without a file-extension (.jpg, etc).
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return base.ToString();
        }

        /// <summary>
        /// Returns the image's path with the file extension.
        /// </summary>
        /// <returns></returns>
        public string ToStringWithExtension()
        {
            return "";
        }
    }
}
