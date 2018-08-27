using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ShaderTools.Shader.General
{
    public class FogParms
    {
        public RGBColor Color { get; set; }

        /// <summary>
        /// Distance to opaque.
        /// </summary>
        [Display(Name = "Opacity", Description = "Distance (in units) to opaque.")]
        [Range(0, double.MaxValue, ErrorMessage = "Must be positive.")]
        public double Opacity { get; set; }
    }
}
