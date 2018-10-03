using ShaderTools.Utilities.Attributes;
using ShaderTools.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects.CompilerDirectives
{
    /// <summary>
    /// 
    /// </summary>
    public interface IDeformVertexes : ICompilerDirective
    {
    }

    /// <summary>
    /// What is this? tr_shader.c line 1094
    /// </summary>
    [Deprecated]
    public class DeformVertexesText : IDeformVertexes { }

    /// <summary>
    /// What is this? tr_shader.c line 1084
    /// </summary>
    public class DeformVertexesProjectionShadow : IDeformVertexes { }

    /// <summary>
    /// Normal autosprite.
    /// </summary>
    [ClassDisplay(Name = "AutoSprite", Description = "Always rendered to player as if looked at from a right angle. Must be used on a square brush face.")]
    [Format(Token.deformVertexes + " " + Token.autosprite)]
    public class DeformVertexesAutosprite : IDeformVertexes { }

    /// <summary>
    /// Pillar autosprite.
    /// </summary>
    [ClassDisplay(Name = "AutoSprite 2", Description = "A sprite, the longest axis of the face is always rendered as if looked at from a right angle.")]
    [Format(Token.deformVertexes + " " + Token.autosprite2)]
    public class DeformVertexesAutosprite2 : IDeformVertexes { }

    /// <summary>
    /// 
    /// </summary>
    [Format(Token.deformVertexes + " " + Token.wave, "division", "waveform")]
    public class DeformVertexesWave : IDeformVertexes
    {
        public int Spread { get; set; }
        public Waveform Waveform { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct DeformVertexesNormal : IDeformVertexes
    {
        public double Frequency { get; set; }
        public double Amplitude { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeformVertexesBulge : IDeformVertexes
    {
        [Display(Name = "Bulge Width", Description = "Displacement on first axis (units)")]
        public double Width { get; set; }

        [Display(Name = "Bulge Height", Description = "Displacement on second axis (units)")]
        public double Height { get; set; }

        [Display(Name = "Speed", Description = "Seconds per cycle")]
        public double Speed { get; set; }

        /// <summary>
        /// deformVertexes bulge 7 5.5 0.5
        /// </summary>
        /// <returns></returns>
        public override string ToString()
        {
            return $"{Token.deformVertexes} {Token.bulge} {Width.ToStr()} {Height.ToStr()} {Speed.ToStr()}";
        }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeformVertexesMove : IDeformVertexes
    {
        public Waveform Waveform { get; set; }
        public double X { get; set; }
        public double Y { get; set; }
        public double Z { get; set; }
    }
}
