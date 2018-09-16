using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;
using ShaderTools.Utilities.Helpers;
using ShaderTools.Utilities.Attributes;

namespace ShaderTools.Objects.Textures
{
    [ClassDisplay(Name = "AnimMap", Description = "")]
    public class AnimMap : ITexture, IValidatableObject
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
        [Display(Name = "Frames")]
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
                //sb.AppendLine(img.ToStringWithExtension());
            }

            return sb.ToString();
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (Images.Count < 1 || Images.Count > 8)
            {
                yield return new ValidationResult($"{Token.animMap} requires 1 to 8 frame(s).");
            }
            if (Frequency < 1)
            {

            }
        }
    }
}
