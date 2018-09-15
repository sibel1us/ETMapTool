using ShaderTools.Utilities.Attributes;
using ShaderTools.Utilities.Helpers;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Objects
{
    [ClassDisplay(Name = "Waveform", Description = "Represents values changing across time.")]
    public class Waveform
    {
        /// <summary>
        /// Waveform function
        /// </summary>
        [Display(Name = "Function", Description = "Waveform function used in the calculation.")]
        public WaveformFunctions Function { get; set; }

        /// <summary>
        /// Initial value.
        /// </summary>
        [Display(Name = "Base", Description = "Initial value.")]
        public double Base { get; set; }

        /// <summary>
        /// Degree of change from the baseline. Values 0.0 to 1.0 are suggested.
        /// </summary>
        [Display(Name = "Amplitude", Description = "Degree of change from the baseline. Values from 0 to 1 are suggested.")]
        public double Amplitude { get; set; }

        /// <summary>
        /// Starting point of the function.
        /// </summary>
        [Display(Name = "Phase", Description = "Starting point of the function.")] // TODO: explain phase better
        public double Phase { get; set; }

        /// <summary>
        /// Peaks per second.
        /// </summary>
        [Display(Name = "Frequency", Description = "Peaks per second.")]
        public double Frequency { get; set; }
    }

    /// <summary>
    /// Represent the different waveform functions used in rgbGen, alphaGen and DeformVertexes.
    /// </summary>
    public enum WaveformFunctions
    {
        [Display(Name = "Sine Wave", Description = "Smooth sine wave.")]
        Sin,

        [Display(Name = "Triangle", Description = "Values incrementally change in linear fashion between extremes.")]
        Triangle,

        [Display(Name = "Square", Description = "Values change instantaneously between extremes.")]
        Square,

        [Display(Name = "Sawtooth", Description = "Values rise in linear fashion to the upper extreme, then instantly start over from the lower.")]
        Sawtooth,

        [Display(Name = "Inverse Sawtooth", Description = "Inverted sawtooth, values descend from the upper extreme instead.")]
        InverseSawtooth
    }
}
