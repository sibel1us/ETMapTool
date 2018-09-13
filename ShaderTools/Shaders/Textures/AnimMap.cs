using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ShaderTools.Shaders.Helpers;
using ShaderTools.Shaders.Attributes;

namespace ShaderTools.Shaders.Textures
{
    [ClassDisplay(Name = "AnimMap", Description = "")]
    public class AnimMap : ITexture
    {
        /// <summary>
        /// Repeats per second.
        /// </summary>
        public int Frequency { get; set; }

        /// <summary>
        /// 
        /// </summary>
        [MinLength(1)]
        [MaxLength(8)]
        public List<Texture> Images { get; set; }

        /// <summary>
        /// animMap 10 path/img1.jpg path/img2.jpg .... line breaks allowed between textures
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            // TODO: improve animmap tostring
            var sb = new StringBuilder("animMap");
            sb.Append($" {this.Frequency}");

            foreach (var img in this.Images)
            {
                sb.AppendLine(img.ToStringWithExtension());
            }

            return sb.ToString();
        }
    }
}
