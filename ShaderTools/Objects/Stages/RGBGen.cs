using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shaders.Stages
{
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

        [Display(Name = "Constant", Description = "")]
        @const
    }

    public class RGBGen : IStageDirective
    {
        public RGBGenType Type { get; private set; }
        public RGBColor Color { get; set; }
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
            if (this.Type == RGBGenType.@const)
            {
                return $"{Token.rgbGen} {this.Type} {this.Color}";
            }
            if (this.Type == RGBGenType.wave)
            {
                return $"{Token.rgbGen} {this.Type} {this.Wave}";

            }

            return $"{Token.rgbGen} {this.Type}";
        }
    }
}
