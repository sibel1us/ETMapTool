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
    /// Normal autosprite.
    /// </summary>
    [ClassDisplay(Name = "AutoSprite", Description = "A sprite, always rendered to player as if looked at from a right angle. Must be used on a square brush face.")]
    public class DeformVertexesAutosprite : IDeformVertexes { }

    /// <summary>
    /// Pillar autosprite.
    /// </summary>
    [ClassDisplay(Name = "AutoSprite 2", Description = "A sprite, the longest axis of the face is always rendered as if looked at from a right angle.")]
    public class DeformVertexesAutosprite2 : IDeformVertexes { }

    /// <summary>
    /// 
    /// </summary>
    public class DeformVertexesWave : IDeformVertexes
    {
        public int Division { get; set; }
        public Waveform Waveform { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public struct DeformVertexesNormal : IDeformVertexes
    {
        public int Division { get; set; }
        public double Base { get; set; }
        public double Amplitude { get; set; }
        public double Frequency { get; set; }
    }

    /// <summary>
    /// 
    /// </summary>
    public class DeformVertexesBulge : IDeformVertexes
    {
        public double S { get; set; }
        public double T { get; set; }
        public double Speed { get; set; }
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
