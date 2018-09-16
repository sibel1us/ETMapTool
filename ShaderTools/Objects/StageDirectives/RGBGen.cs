using ShaderTools.Objects;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.StageDirectives
{
    /// <summary>
    /// 
    /// </summary>
    public enum RGBGenType
    {
        [Display(Name = "Identity", Description = "")]
        identity,

        [Display(Name = "Identity Lighting", Description = "")]
        identityLighting,

        [Display(Name = "Entity", Description = "")]
        entity,

        [Display(Name = "One minus Entity", Description = "")]
        oneMinusEntity,

        [Display(Name = "Vertex", Description = "")]
        vertex,

        [Display(Name = "Lighting Diffuse", Description = "")]
        lightingDiffuse,

        [Display(Name = "Wave", Description = "")]
        wave,

        [Display(Name = "Constant", Description = "Apply a color filter on the surface.")]
        @const
    }

    /// <summary>
    /// Affects how color is calculated on the layer.
    /// </summary>
    public class RGBGen : IStageDirective
    {
        /// <summary>
        /// Value of the RGBGen. See <see cref="Color"/> and <see cref="Wave"/>.
        /// </summary>
        public RGBGenType Type { get; private set; }

        /// <summary>
        /// Only applicable if <see cref="Type"/> is <see cref="RGBGenType.@const"/>.
        /// </summary>
        public RGBColor Color { get; set; }

        /// <summary>
        /// Only applicable if <see cref="Type"/> is <see cref="RGBGenType.wave"/>.
        /// </summary>
        public Waveform Wave { get; set; }

        /// <summary>
        /// Initialize rgbGen
        /// </summary>
        /// <param name="type"></param>
        public RGBGen(RGBGenType type)
        {
            this.Type = type;
        }

        /// <summary>
        /// Initialize RGBGen const
        /// </summary>
        /// <param name="constValue"></param>
        public RGBGen(RGBColor color)
        {
            this.Type = RGBGenType.@const;
            this.Color = color;
        }

        /// <summary>
        /// Initialize RGBGen wave
        /// </summary>
        /// <param name="waveform"></param>
        public RGBGen(Waveform waveform)
        {
            this.Type = RGBGenType.wave;
            this.Wave = waveform;
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            switch (this.Type)
            {
                case RGBGenType.wave:
                    return $"{Token.rgbGen} {this.Type} {this.Wave}";
                case RGBGenType.@const:
                    return $"{Token.rgbGen} {this.Type} {this.Color}";
                default:
                    return $"{Token.rgbGen} {this.Type}";
            }
        }
    }
}
